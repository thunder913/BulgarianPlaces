using BulgarianPlaces.Models.Enums;
using BulgarianPlaces.Models.HttpModels;
using BulgarianPlaces.ViewModels.Ranking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BulgarianPlaces.Views.Ranking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllTimeRankingPage : ContentPage
    {
        public HttpClient client = new HttpClient();
        public ObservableCollection<RankingUserDto> People { get; set; } = new ObservableCollection<RankingUserDto>();
        public AllTimeRankingPage()
        {
            InitializeComponent();
            PeopleView.ItemsSource = People;
            BindingContext = new RankingViewModel();

            // TODO refactor all the ranking classes and make them reuse same interface
            Title = "Ranking";
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Task.Run(async () =>
            {
                Uri uri = new Uri(string.Format(GlobalConstants.Url + "User/ranking/" + RankingType.AllTime));
                var result = await client.GetAsync(uri);
                var responseAsString = await result.Content.ReadAsStringAsync();
                var peopleRanked = JsonConvert.DeserializeObject<List<RankingUserDto>>(responseAsString);
                this.People.Clear();
                foreach (var person in peopleRanked)
                {
                    this.People.Add(person);
                }
            }).Wait();
        }

        private void PeopleView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = ((ListView)sender).SelectedItem;
            //TODO redirect to profile page
        }
    }
}