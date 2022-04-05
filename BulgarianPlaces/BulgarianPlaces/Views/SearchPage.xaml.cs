using BulgarianPlaces.Models;
using BulgarianPlaces.Models.Enums;
using BulgarianPlaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static BulgarianPlaces.Handlers.MySearchHandler;

namespace BulgarianPlaces.Views
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            Title = "Search people and landmarks";
            BindingContext = new SearchViewModel();
        }

        public async void OnItemSelected(object item, SelectedItemChangedEventArgs e)
        {
            var listView = (ListView)item;

            var search = (Models.SearchResult)listView.SelectedItem;

            if (search.SearchType == SearchResultType.Person)
            {
                await Shell.Current.GoToAsync($"//SearchPage/{nameof(ProfilePage)}?{nameof(search.Id)}={search.Id}");
            }
            else
            {
                await Shell.Current.GoToAsync($"//SearchPage/{nameof(PlacePage)}?{nameof(search.Id)}={search.Id}");
            }
        }
    }
}