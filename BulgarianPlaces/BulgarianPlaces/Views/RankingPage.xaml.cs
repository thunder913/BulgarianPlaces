using BulgarianPlaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BulgarianPlaces.Views
{
    [QueryProperty(nameof(PageType), nameof(PageType))]
    public partial class RankingPage : ContentPage
    {
        private string pageType { get; set; }
        public string PageType
        {
            get
            {
                return pageType;
            }
            set
            {
                pageType = value;
            }
        }
        public RankingPage()
        {
            InitializeComponent();
            BindingContext = new RankingViewModel();
            Title = PageType;
        }
    }
}