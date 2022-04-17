using BulgarianPlaces.Models.HttpModels;
using BulgarianPlaces.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BulgarianPlaces.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfileViewModel vm { get; set; }
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = vm = new ProfileViewModel(true);
        }

        public async void OnItemSelected(object item, SelectedItemChangedEventArgs e)
        {
            var listView = (ListView)item;

            var profile = (ProfilePlaceVisitedDto)listView.SelectedItem;
            if (profile == null)
                return;
            var location = await Geolocation.GetLastKnownLocationAsync();
            var stack = Shell.Current.Navigation.NavigationStack;
            await Shell.Current.GoToAsync($"{nameof(PlaceVisitedPage)}?{nameof(ProfilePlaceVisitedDto.Id)}={profile.Id}&IsMyProfile={vm.UserId == null}");
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
            await Shell.Current.GoToAsync($"/{nameof(ImagePage)}?ImageSource=" + vm.Profile.Image);
        }

        protected override void OnAppearing()
        {
            vm.SetUserProfile();
        }
    }
}