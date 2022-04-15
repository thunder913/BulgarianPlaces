using BulgarianPlaces.Models;
using BulgarianPlaces.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace BulgarianPlaces.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminApprovalPage : ContentPage
    {
        public AdminApprovalViewModel vm { get; set; }
        private Models.SearchResult SelectedItem { get; set; }
        public AdminApprovalPage()
        {
            InitializeComponent();
            BindingContext = vm = new AdminApprovalViewModel(MyMap);
            Title = "Request Approval";
        }

        public async void OnItemSelected(object item, SelectedItemChangedEventArgs e)
        {
            var listView = (ListView)item;

            SelectedItem = (Models.SearchResult)listView.SelectedItem;
        }

        private void searchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            var searchBar = (SearchBar)sender;
            try
            {
                vm.NewPlace = string.Empty;
                vm.SearchResults.Clear();
                Task.Run(async () =>
                {
                    Uri uri = new Uri(string.Format(GlobalConstants.Url + $"Place/Search/{searchBar.SearchCommandParameter}"));
                    var result = await vm.client.GetAsync(uri);
                    var responseAsString = await result.Content.ReadAsStringAsync();
                    var items = JsonConvert.DeserializeObject<List<SearchResult>>(responseAsString);
                    foreach (var item in items)
                    {
                        vm.SearchResults.Add(item);
                    }
                }).Wait();
                if (vm.SearchResults.Any())
                {
                    SearchResults.HeightRequest = 100;
                }
            }
            catch (Exception)
            {

            }
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

            var searchBar = (SearchBar)sender;
            if (string.IsNullOrWhiteSpace(searchBar.SearchCommandParameter.ToString()))
            {
                vm.SearchResults.Clear();
                SearchResults.HeightRequest = 0;
                SelectedItem = null;
            }
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(vm.NewPlace))
            {
                vm.SearchResults.Clear();
                SearchResults.HeightRequest = 0;
                searchBar.Text = string.Empty;
            }
        }

        private async void AcceptButtonClicked(object sender, EventArgs e)
        {
            Uri uri = new Uri(string.Format(GlobalConstants.Url + $"Review/approve"));
            var form = new MultipartFormDataContent();
            form.Add(new StringContent(vm.Id), "id");
            form.Add(new StringContent(SelectedItem?.Id.ToString() ?? string.Empty), "placeId");
            form.Add(new StringContent(Application.Current.Properties["token"].ToString()), "jwtToken");
            var result = await vm.client.PostAsync(uri, form);
            var responseAsString = await result.Content.ReadAsStringAsync();
            if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                vm.ErrorMessage = "Провери, дали си избрал мястото, където се намира ревюто.";
                await DisplayAlert("Грешка", vm.ErrorMessage, "Ок");
            }
            else
            {
                await Shell.Current.GoToAsync($"..");
            }
        }

        private async void DeclineButtonClicked(object sender, EventArgs e)
        {
            Uri uri = new Uri(string.Format(GlobalConstants.Url + $"Review/decline"));
            var form = new MultipartFormDataContent();
            form.Add(new StringContent(vm.Id), "id");
            form.Add(new StringContent(SelectedItem?.Id.ToString() ?? string.Empty), "placeId");
            form.Add(new StringContent(Application.Current.Properties["token"].ToString()), "jwtToken");
            var result = await vm.client.PostAsync(uri, form);
            var responseAsString = await result.Content.ReadAsStringAsync();
            await Shell.Current.GoToAsync($"..");
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"/{nameof(ImagePage)}?ImageSource=" + vm.Request.Image);
        }
    }
}