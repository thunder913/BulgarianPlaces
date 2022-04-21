using BulgarianPlaces.Handlers;
using BulgarianPlaces.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BulgarianPlaces.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstTimePage : ContentPage
    {
        public string ImageBase64 { get; set; }
        private FirstTimeViewModel vm { get; set; }
        private HttpClient client { get; set; }
        public FirstTimePage()
        {
            client = new HttpClient();
            InitializeComponent();
            BindingContext = vm = new FirstTimeViewModel(image);
        }

        async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {
            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                var bytes = new byte[stream.Length];
                await stream.ReadAsync(bytes, 0, (int)stream.Length);
                ImageBase64 = Convert.ToBase64String(bytes);
                vm.ChangeImage(ImageBase64);
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (ImageBase64 is null)
            {
                await this.DisplayAlert("Успех", "Трябва да качиш снимка, която ще ти бъде профилна снимка и ще бъде видима за всички потребители!", null, "OK");
            }
            else if (string.IsNullOrWhiteSpace(vm.Description) || vm.Description.Length < 5)
            {
                await this.DisplayAlert("Успех", "Трябва да въведеш описание, което е поне 5 символа!", null, "OK");
            }
            else if (string.IsNullOrWhiteSpace(vm.FirstName) || string.IsNullOrWhiteSpace(vm.LastName))
            {
                await this.DisplayAlert("Успех", "Трябва да въведеш първо и фамилно име!", null, "OK");
            }
            else
            {
                Uri uri = new Uri(string.Format(GlobalConstants.Url + $"User/FinishFirstTime"));
                var form = new MultipartFormDataContent();
                form.Add(new StringContent(ImageBase64 ?? string.Empty), "image");
                form.Add(new StringContent(vm.Description ?? string.Empty), "description");
                form.Add(new StringContent(vm.FirstName ?? string.Empty), "firstName");
                form.Add(new StringContent(vm.LastName ?? string.Empty), "lastName");
                form.Add(new StringContent(Application.Current.Properties["token"].ToString()), "jwt");
                form.Headers.ContentType.MediaType = "multipart/form-data";
                var result = await client.PostAsync(uri, form);
                var responseAsString = await result.Content.ReadAsStringAsync();
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    await Shell.Current.GoToAsync($"//{nameof(ProfilePage)}");
                }
                else
                {
                    await this.DisplayAlert("Успех", "Нещо се обърка, провери си входните данни и опитай отново!", null, "OK");
                }
            }
        }
    }
}