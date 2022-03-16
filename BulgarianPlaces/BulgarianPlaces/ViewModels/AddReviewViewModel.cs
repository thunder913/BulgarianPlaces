using BulgarianPlaces.Handlers;
using BulgarianPlaces.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace BulgarianPlaces.ViewModels
{
    public class AddReviewViewModel : BaseViewModel
    {
        public Image image { get; set; } = new Image();
        public AddReviewViewModel()
        {
            image.Source = "add_image.png";
        }

        public ICommand PerformSearch => new Command<string>((string query) =>
        {
            Console.WriteLine(query);
            Console.WriteLine(query);
            //TODO add logic ot get the correct results
            var results = new List<SearchResult>();
            results.Add(new Models.SearchResult() { Id = 1, Image = "admin.png", Name = "Ivan Todorov", RightColumnNumber = "15" });
            results.Add(new Models.SearchResult() { Id = 2, Image = "admin.png", Name = "Ivan Todorov", RightColumnNumber = "11" });
            results.Add(new Models.SearchResult() { Id = 3, Image = "admin.png", Name = "Ivan Todorov", RightColumnNumber = "12" });
        });
    }
}
