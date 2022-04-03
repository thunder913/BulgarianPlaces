using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace BulgarianPlaces.ViewModels
{
    [QueryProperty(nameof(ImageSource), nameof(ImageSource))]
    public class ImageViewModel : BaseViewModel
    {
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
    }
}
