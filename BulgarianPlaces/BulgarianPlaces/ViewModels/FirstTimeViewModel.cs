using System;
using System.IO;
using Xamarin.Forms;

namespace BulgarianPlaces.ViewModels
{
    public class FirstTimeViewModel : BaseViewModel
    {
        public Image Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public FirstTimeViewModel(Image image)
        {
            this.Image = image;
            image.Source = "add_image.png";
        }

        public void ChangeImage(string base64Text)
        {
            Image.Source = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(base64Text)));
            OnPropertyChanged(nameof(Image));
        }
    }
}
