using BulgarianPlaces.Models;
using BulgarianPlaces.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace BulgarianPlaces.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        public HttpClient client { get; set; }
        public ObservableCollection<SearchResult> SearchResults { get; set; } = new ObservableCollection<SearchResult>();
        public SearchViewModel()
        {
            client = new HttpClient();
        }
        public ICommand PerformSearch => new Command<string>((string query) =>
        {
            Task.Run(async () =>
            {
                Uri uri = new Uri(string.Format(GlobalConstants.Url + "Search/"+query));
                var result = await client.GetAsync(uri);
                SearchResults.Clear();
                var responseAsString = await result.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<List<SearchResult>>(responseAsString);
                foreach (var item in results)
                {
                    SearchResults.Add(item);
                }
            }).Wait();
            OnPropertyChanged(nameof(SearchResults));
        });
    }
}
