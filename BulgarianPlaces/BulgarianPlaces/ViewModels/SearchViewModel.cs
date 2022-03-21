using BulgarianPlaces.Models;
using BulgarianPlaces.Models.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace BulgarianPlaces.ViewModels
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Models.SearchResult> Results { get; set; } = new ObservableCollection<Models.SearchResult>();
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand PerformSearch => new Command<string>((string query) =>
        {
            Console.WriteLine(query);
            Console.WriteLine(query);
            //TODO add logic ot get the correct results
            var results = new List<SearchResult>();
            results.Add(new Models.SearchResult() { Id = 1, Image = "admin.png", Name = "Ivan Todorov", RightColumnNumber = "15", SearchType = SearchType.Person });
            results.Add(new Models.SearchResult() { Id = 2, Image = "admin.png", Name = "Ivan Todorov", RightColumnNumber = "11", SearchType = SearchType.Person });
            results.Add(new Models.SearchResult() { Id = 3, Image = "admin.png", Name = "Ivan Todorov", RightColumnNumber = "12", SearchType = SearchType.Person });
            results.Add(new Models.SearchResult() { Id = 4, Image = "ranking.png", Name = "Shipka", RightColumnNumber = "12", SearchType = SearchType.Place });
            SearchResults = results;
        });

        private List<SearchResult> searchResults;
        public List<SearchResult> SearchResults
        {
            get
            {
                return searchResults;
            }
            set
            {
                searchResults = value;
                NotifyPropertyChanged();
            }
        }
    }
}
