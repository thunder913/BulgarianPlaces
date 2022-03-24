using BulgarianPlaces.Models.HttpModels;
using BulgarianPlaces.Views;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BulgarianPlaces.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class PlaceVisitedViewModel : BaseViewModel
    {
        public Action<int, Color> ChangeColor { get; set; }
        public PlaceVisitedViewModel(Action<int, Color> changeColor)
        {
            this.ChangeColor = changeColor;
        }

        private HttpClient client = new HttpClient();
        private int id;
        public int Id
        {
            get => id; 
            set
            {
                this.id = value;
                this.LoadItemId(value);
            }
        }
        private PlaceReviewDto place;
        public PlaceReviewDto Place { get => place; set => SetProperty(ref place, value); }
        public void LoadItemId(int id)
        {
            Task.Run(async () =>
            {
                try
                {
                    Uri uri = new Uri(string.Format(GlobalConstants.Url + "Review/"+id));
                    var result = await client.GetAsync(uri);
                    var responseAsString = await result.Content.ReadAsStringAsync();
                    this.Place = JsonConvert.DeserializeObject<PlaceReviewDto>(responseAsString);
                    this.ChangeColor(this.Place.Rating, Color.Black);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }).Wait();
        }

    }
}
