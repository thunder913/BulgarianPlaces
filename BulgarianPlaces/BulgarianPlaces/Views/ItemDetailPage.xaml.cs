using BulgarianPlaces.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BulgarianPlaces.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}