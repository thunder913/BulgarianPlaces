using BulgarianPlaces.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using Xamarin.Forms;

namespace BulgarianPlaces.ViewModels
{
    [QueryProperty(nameof(ImageSource), nameof(ImageSource))]
    [QueryProperty(nameof(Route), nameof(Route))]
    public class ImageViewModel : BaseViewModel
    {
        private string route;
        public string Route
        {
            get { return route; }
            set
            {
                SetProperty(ref route, value);
            }
        }
        private string image;
        public string Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }
        public string imageSource;
        public string ImageSource
        {
            get { return imageSource; }
            set
            {
                this.imageSource = value;
                ChangeImage(value);
            }
        }
        public ImageViewModel()
        {
        }

        public void ChangeImage(string image)
        {
            this.Image = image;
        }

        public ICommand BackCommand => new Command<string>(async (string query) =>
        {
            if (this.Route is null)
            {
                await Shell.Current.Navigation.PopAsync();
            }
            else
            {
                await Shell.Current.GoToAsync(this.Route);
            }
        });
    }
}
