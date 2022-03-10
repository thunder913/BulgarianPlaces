using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BulgarianPlaces.Handlers
{
    public class MySearchHandler : SearchHandler
    {
        public Type SelectedItemNavigationTarget { get; set; }
        public IList<SearchResult> Test { get; set; } = new List<SearchResult>() { new SearchResult("Ivan"), new SearchResult("Ivanka"), new SearchResult("Pesho"), new SearchResult("Andon") };
        
        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);
            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = Test.Where(x => x.Name.ToLower().Contains(newValue.ToLower()));
            }
        }

        protected override async void OnItemSelected(object item)
        {
            //base.OnItemSelected(item);

            //await Task.Delay(1000);

            //ShellNavigationState state = (App.Current.MainPage as Shell).CurrentState;
            //await Shell.Current.GoToAsync($"{GetNavigationTarget()}?name={((Animal)item).Name}");
        }

        public class SearchResult
        {
            public SearchResult(string name)
            {
                this.Name = name;
            }
            public string Name { get; set; }
        }

        //private string GetNavigationTarget()
        //{
        //    return (Shell.Current as AppShell).Routes.FirstOrDefault(route => route.Value.Equals(SelectedItemNavigationTarget)).Key;
        //}
    }
}
