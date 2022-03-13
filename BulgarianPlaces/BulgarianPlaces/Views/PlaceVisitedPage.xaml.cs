using BulgarianPlaces.ViewModels;
using System;
using Xamarin.Forms;

namespace BulgarianPlaces.Views
{
    public partial class PlaceVisitedPage : ContentPage
    {
        public PlaceVisitedPage()
        {
            InitializeComponent();
            BindingContext = new PlaceVisitedViewModel();

            Reset();
        }

        void Reset()
        {
            ChangeTextColor(4, Color.Black);
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

        //private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        //{
        //    Reset();
        //    Label clicked = sender as Label;
        //    ChangeTextColor(Convert.ToInt32(clicked.StyleId.Substring(4, 1)), Color.Black);
        //}
    }
}