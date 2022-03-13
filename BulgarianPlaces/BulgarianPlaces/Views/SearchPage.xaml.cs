using BulgarianPlaces.Models;
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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {

        public SearchPage()
        {
            InitializeComponent();
            Title = "Search people and landmarks";
            BindingContext = new SearchViewModel();

        }
    }
}