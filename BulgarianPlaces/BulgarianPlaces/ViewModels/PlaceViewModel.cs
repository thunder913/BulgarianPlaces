using BulgarianPlaces.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BulgarianPlaces.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class PlaceViewModel : BaseViewModel
    {
        HttpClient client;
        public PlaceDto Place { get; set; }
        public int? PlaceId { get; set; }
        private string id;
        public string Id
        {
            get => id;
            set
            {
                this.id = value;
                if (int.TryParse(value, out int res))
                {
                    PlaceId = res;
                }
                SetPlace();
            }
        }

        public PlaceViewModel()
        {
            client = new HttpClient();
        }

        public void SetPlace()
        {
            Task.Run(async () =>
            {
                Uri uri = new Uri(string.Format(GlobalConstants.Url + "Place/" + PlaceId));
                var result = await client.GetAsync(uri);
                var responseAsString = await result.Content.ReadAsStringAsync();
                Place = JsonConvert.DeserializeObject<PlaceDto>(responseAsString);
            }).Wait();
            OnPropertyChanged(nameof(Place));
        }
    }
}
