using BulgarianPlaces.Models.HttpModels;
using BulgarianPlaces.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BulgarianPlaces.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = new ProfileViewModel();
            Shell.SetTabBarIsVisible(this, true);

        }
        async void OnItemSelected(object item, SelectedItemChangedEventArgs e)
        {
            var listView = (ListView)item;

            var profile = (ProfilePlaceVisitedDto)listView.SelectedItem;
            if (profile == null)
                return;
            var location = await Geolocation.GetLastKnownLocationAsync();
            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(PlaceVisitedPage)}?{nameof(ProfilePlaceVisitedDto.Id)}={profile.Id}");
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            if (Application.Current.Properties.TryGetValue("token", out var _))
            {
                Application.Current.Properties.Clear();
                Task.Run(async () =>
                {
                    await Application.Current.SavePropertiesAsync();
                }).Wait();

            }
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(ImagePage)}?ImageSource=admin.png");
        }
    }
}