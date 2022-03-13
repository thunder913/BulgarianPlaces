using BulgarianPlaces.Models;
using BulgarianPlaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BulgarianPlaces.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ObservableCollection<ProfilePlace> Places { get; set; } = new ObservableCollection<ProfilePlace>();
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = new ProfileViewModel();

            PlacesVisited.ItemsSource = Places;
            Places.Add(new ProfilePlace() { Id = 1, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            Places.Add(new ProfilePlace() { Id = 2, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            Places.Add(new ProfilePlace() { Id = 3, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            Places.Add(new ProfilePlace() { Id = 4, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            Places.Add(new ProfilePlace() { Id = 5, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            Places.Add(new ProfilePlace() { Id = 6, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            Places.Add(new ProfilePlace() { Id = 7, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            Places.Add(new ProfilePlace() { Id = 8, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            Places.Add(new ProfilePlace() { Id = 9, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            Places.Add(new ProfilePlace() { Id = 10, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            Places.Add(new ProfilePlace() { Id = 11, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            Places.Add(new ProfilePlace() { Id = 12, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            Places.Add(new ProfilePlace() { Id = 13, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            Places.Add(new ProfilePlace() { Id = 14, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            Places.Add(new ProfilePlace() { Id = 15, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            Places.Add(new ProfilePlace() { Id = 16, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            Places.Add(new ProfilePlace() { Id = 17, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            Places.Add(new ProfilePlace() { Id = 18, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            Places.Add(new ProfilePlace() { Id = 19, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            Places.Add(new ProfilePlace() { Id = 20, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            Places.Add(new ProfilePlace() { Id = 21, Name = "Shipka", Date = "12/03/2022", Rating = 4 });
            Places.Add(new ProfilePlace() { Id = 22, Name = "Shipka", Date = "12/03/2022", Rating = 4 });

        }
        async void OnItemSelected(object item, SelectedItemChangedEventArgs e)
        {
            var listView = (ListView)item;

            var profile = (ProfilePlace)listView.SelectedItem;
            if (profile == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(PlaceVisitedPage)}?{nameof(ProfilePlace.Id)}={profile.Id}");
        }
    }
}