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
        }
    }
}