using BulgarianPlaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BulgarianPlaces.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlacePage : ContentPage
    {
        public PlaceViewModel vm { get; set; }
        public PlacePage()
        {
            InitializeComponent();
            this.BindingContext = vm = new PlaceViewModel();
            Title = "Place";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Uri uri = new Uri($"https://maps.google.com/?q={vm.Place.Latitude},{vm.Place.Longitude}");
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"/{nameof(ImagePage)}?ImageSource=" + vm.Place.Image);
        }
    }
}