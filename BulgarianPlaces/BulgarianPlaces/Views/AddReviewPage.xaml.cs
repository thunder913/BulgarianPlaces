using BulgarianPlaces.Handlers;
using BulgarianPlaces.Models;
using BulgarianPlaces.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace BulgarianPlaces.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddReviewPage : ContentPage
    {
        protected HttpClient client;
        public string ImageBase64 { get; set; }
        public event EventHandler<Xamarin.Forms.Maps.MapClickedEventArgs> MapClicked;
        public static Position Position = new Position();
        public static int Rating { get; set; } = 3;
        private AddReviewViewModel vm { get; set; }
        public AddReviewPage()
        {
            this.client = new HttpClient();
            InitializeComponent();
            BindingContext = vm = new AddReviewViewModel(SubmitReview, image);

            Reset();
            ChangeTextColor(Rating, Color.Black);

            var position = new Position(42.7249925, 25.4833039);
            MyMap.MoveToRegion(new MapSpan(position, 3, 3));
            MyMap.MapClicked += Map_MapClicked;

        }

        void Reset()
        {
            ChangeTextColor(5, Color.LightGray);
        }

        void ChangeTextColor(int starcount, Color color)
        {
            for (int i = 1; i <= starcount; i++)
            {
                (FindByName($"star{i}") as Label).TextColor = color;
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Reset();
            Label clicked = sender as Label;
            Rating = Convert.ToInt32(clicked.StyleId.Substring(4, 1));
            ChangeTextColor(Rating, Color.Black);
        }

        public void Map_MapClicked(object sender, MapClickedEventArgs e)
        {
            MyMap.Pins.Clear();
            Position = new Position(e.Position.Latitude, e.Position.Longitude);
            MyMap.Pins.Add(new Pin
            {
                Label = "Pin from tap",
                Position = Position,
            });
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

        public async void SubmitReview(Image image, string description)
        {
            var pin = MyMap.Pins.FirstOrDefault();
            if (ImageBase64 is null)
            {
                await this.DisplayAlert("Грешка", "Трябва да сложиш твоя снимка от мястото. Тя ще бъде видима за всички потребители, след одобрението от администратор.", "OK");
            }
            else if (description is null || description.Length < 3)
            {
                await this.DisplayAlert("Грешка", "Трябва да попълниш описание от поне 3 символа, за да информираш всички относно твоето мнение от мястото.", "OK");
            }
            else if (pin is null)
            {
                await this.DisplayAlert("Грешка", "Избери място на картата, за да можем да валидираме, че си посетил забележителността.", "OK");
            }
            else
            {
                try
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                    CancellationTokenSource cts = new CancellationTokenSource();
                    var location = await Geolocation.GetLocationAsync(request, cts.Token);
                    Uri uri = new Uri(string.Format(GlobalConstants.Url + $"Review/Add"));
                    var form = new MultipartFormDataContent();
                    form.Add(new StringContent(ImageBase64), "image");
                    form.Add(new StringContent(description ?? string.Empty), "description");
                    form.Add(new StringContent(Rating.ToString()), "rating");
                    form.Add(new StringContent(pin.Position.Latitude.ToString()), "chosenLatitude");
                    form.Add(new StringContent(pin.Position.Longitude.ToString()), "chosenLongitude");
                    form.Add(new StringContent(Checkbox.IsChecked.ToString()), "isAtLocation");
                    form.Add(new StringContent(location.Latitude.ToString()), "userLatitude");
                    form.Add(new StringContent(location.Longitude.ToString()), "userLongitude");
                    form.Add(new StringContent(Application.Current.Properties["token"].ToString()), "jwt");
                    form.Headers.ContentType.MediaType = "multipart/form-data";
                    var result = await client.PostAsync(uri, form);
                    var responseAsString = await result.Content.ReadAsStringAsync();
                }
                catch (Exception)
                {
                    await this.DisplayAlert("Грешка", "Нещо се обърка, моля опитай отново.", "OK");
                }

                var alertResult = await this.DisplayAlert("Успех", "Успешно си изпрати ревюто за одобрение! Когато бъде одобрено ще можеш да го видиш на профила си!", null, "OK");
                if (!alertResult)
                {
                    await Shell.Current.Navigation.PopToRootAsync();
                }
            }
        }
    }
}