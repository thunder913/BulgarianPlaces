using BulgarianPlaces.Models;
using BulgarianPlaces.Models.HttpModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace BulgarianPlaces.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class AdminApprovalViewModel : BaseViewModel
    {
        private string _errorMessage { get; set; }
        public string ErrorMessage
        {
            get => _errorMessage; set
            {
                _errorMessage = value;
                this.OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public ObservableCollection<SearchResult> SearchResults { get; set; } = new ObservableCollection<SearchResult>();
        public AdminApprovalDto Request { get; set; }
        public HttpClient client { get; set; }
        private string _newPlace { get; set; }
        public string NewPlace
        {
            get => _newPlace; set
            {
                _newPlace = value;
                this.OnPropertyChanged(nameof(NewPlace));
            }
        }
        public int RequestId { get; set; }
        private string id;
        public string Id
        {
            get => id;
            set
            {
                this.id = value;
                if (int.TryParse(value, out int res))
                {
                    RequestId = res;
                }
                SetRequestId();
            }
        }
        private Map Map { get; set; }
        public AdminApprovalViewModel(Map map)
        {
            client = new HttpClient();
            Map = map;
        }

        private void SetRequestId()
        {
            Task.Run(async () =>
            {
                try
                {
                    Uri uri = new Uri(string.Format(GlobalConstants.Url + "Review/adminreview/" + RequestId));
                    var result = await client.GetAsync(uri);
                    var responseAsString = await result.Content.ReadAsStringAsync();
                    Request = JsonConvert.DeserializeObject<AdminApprovalDto>(responseAsString);

                    var location = new Position((double)Request.LocationLatitude, (double)Request.LocationLongitude);
                    Map.MoveToRegion(new MapSpan(location, 1, 1));
                    Map.Pins.Add(new Pin
                    {
                        Label = "Location",
                        Position = location,
                    });
                    Map.Pins.Add(new Pin
                    {
                        Label = "Added from",
                        Position = new Position((double)Request.UserLatitude, (double)Request.UserLongitude),
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }).Wait();
            OnPropertyChanged(nameof(Request));
        }
    }
}
