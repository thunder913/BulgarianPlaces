using BulgarianPlaces.Handlers;
using BulgarianPlaces.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace BulgarianPlaces.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddReviewPage : ContentPage
    {
        public event EventHandler<Xamarin.Forms.Maps.MapClickedEventArgs> MapClicked;
        private AddReviewViewModel vm { get; set; }
        public AddReviewPage()
        {
            InitializeComponent();
            BindingContext = vm = new AddReviewViewModel();
            
            Reset();
            ChangeTextColor(3, Color.Black);

            var position = new Position(42.7249925, 25.4833039);
            MyMap.MoveToRegion(new MapSpan(position, 3, 3));
            MyMap.MapClicked += Map_MapClicked;
        }

        void Reset()
        {
            ChangeTextColor(5, Color.LightGray);
        }

        void ChangeTextColor(int starcount, Color color)
        {
            for (int i = 1; i <= starcount; i++)
            {
                (FindByName($"star{i}") as Label).TextColor = color;
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Reset();
            Label clicked = sender as Label;
            ChangeTextColor(Convert.ToInt32(clicked.StyleId.Substring(4, 1)), Color.Black);
        }

        public void Map_MapClicked(object sender, MapClickedEventArgs e)
        {
            MyMap.Pins.Clear();
            MyMap.Pins.Add(new Pin
            {
                Label = "Pin from tap",
                Position = new Position(e.Position.Latitude, e.Position.Longitude),
            });
        }

        async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {
            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                vm.image.Source = ImageSource.FromStream(() => stream);
            }
        }

    }
}