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

        public void SubmitReview(Image image, string description)
        {
            Task.Run(async () =>
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                CancellationTokenSource cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);
                Uri uri = new Uri(string.Format(GlobalConstants.Url + $"Review/Add"));
                var form = new MultipartFormDataContent();
                form.Add(new StringContent(ImageBase64), "image");
                form.Add(new StringContent(description ?? string.Empty), "description");
                form.Add(new StringContent(Rating.ToString()), "rating");
                form.Add(new StringContent(Position.Latitude.ToString()), "chosenLatitude");
                form.Add(new StringContent(Position.Longitude.ToString()), "chosenLongitude");
                form.Add(new StringContent(Checkbox.IsChecked.ToString()), "isAtLocation");
                form.Add(new StringContent(location.Latitude.ToString()), "userLatitude");
                form.Add(new StringContent(location.Longitude.ToString()), "userLongitude");
                form.Add(new StringContent(Application.Current.Properties["token"].ToString()), "jwt");
                form.Headers.ContentType.MediaType = "multipart/form-data";
                var result = await client.PostAsync(uri, form);
                var responseAsString = await result.Content.ReadAsStringAsync();
            }).Wait();
        }

    }
}