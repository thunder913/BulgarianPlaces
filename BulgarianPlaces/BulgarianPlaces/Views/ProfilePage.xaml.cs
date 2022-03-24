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
            //PlacesVisited.ItemsSource = Places;
            //Places.Add(new ProfilePlace() { Id = 1, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            //Places.Add(new ProfilePlace() { Id = 2, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            //Places.Add(new ProfilePlace() { Id = 3, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            //Places.Add(new ProfilePlace() { Id = 4, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            //Places.Add(new ProfilePlace() { Id = 5, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            //Places.Add(new ProfilePlace() { Id = 6, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            //Places.Add(new ProfilePlace() { Id = 7, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            //Places.Add(new ProfilePlace() { Id = 8, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            //Places.Add(new ProfilePlace() { Id = 9, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            //Places.Add(new ProfilePlace() { Id = 10, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            //Places.Add(new ProfilePlace() { Id = 11, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            //Places.Add(new ProfilePlace() { Id = 12, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            //Places.Add(new ProfilePlace() { Id = 13, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            //Places.Add(new ProfilePlace() { Id = 14, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            //Places.Add(new ProfilePlace() { Id = 15, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            //Places.Add(new ProfilePlace() { Id = 16, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            //Places.Add(new ProfilePlace() { Id = 17, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            //Places.Add(new ProfilePlace() { Id = 18, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            //Places.Add(new ProfilePlace() { Id = 19, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            //Places.Add(new ProfilePlace() { Id = 20, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            //Places.Add(new ProfilePlace() { Id = 21, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            //Places.Add(new ProfilePlace() { Id = 22, Name = "Shipka", Date = "12/03/2022", Rating = 4 });

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