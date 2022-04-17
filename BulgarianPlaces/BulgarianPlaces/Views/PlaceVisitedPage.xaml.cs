using BulgarianPlaces.ViewModels;
using System;
using System.Web;
using Xamarin.Forms;

namespace BulgarianPlaces.Views
{
    public partial class PlaceVisitedPage : ContentPage
    {
        private PlaceVisitedViewModel vm { get; set; }
        public PlaceVisitedPage()
        {
            InitializeComponent();
            BindingContext = vm = new PlaceVisitedViewModel(ChangeTextColor);
            Title = "Ревю";
        }

        void Reset()
        {
            ChangeTextColor(vm.Place.Rating, Color.Black);
        }

        void ChangeTextColor(int starcount, Color color)
        {
            for (int i = 1; i <= 5; i++)
            {
                (FindByName($"star{i}") as Label).TextColor = Color.LightGray;
            }
            for (int i = 1; i <= starcount; i++)
            {
                (FindByName($"star{i}") as Label).TextColor = color;
            }
        }

        async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            string url = string.Empty;
            if (vm.IsMyProfile)
            {
                url = $"//{nameof(ProfilePage)}/{nameof(PlaceVisitedPage)}?Id=" + vm.Id;
            }
            else
            {
                url = $"//LastWeekRankingPage/{nameof(ProfilePage)}/{nameof(PlaceVisitedPage)}?Id=" + vm.Id;
            }
            var encodedUrl = HttpUtility.UrlEncode(url);
            await Shell.Current.GoToAsync($"/{nameof(ImagePage)}?ImageSource={vm.Place.Image}&Route={encodedUrl}");
        }

        //private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        //{
        //    Reset();
        //    Label clicked = sender as Label;
        //    ChangeTextColor(Convert.ToInt32(clicked.StyleId.Substring(4, 1)), Color.Black);
        //}
    }
}