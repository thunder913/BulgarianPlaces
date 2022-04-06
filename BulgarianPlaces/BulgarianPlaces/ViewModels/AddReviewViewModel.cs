using BulgarianPlaces.Handlers;
using BulgarianPlaces.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace BulgarianPlaces.ViewModels
{
    public class AddReviewViewModel : BaseViewModel
    {
        public Image Image { get; set; }
        public string Description { get; set; }
        public Action<Image, string> AddReview;
        public Command SubmitReview { get; }
        public AddReviewViewModel(Action<Image, string> addReview, Image image)
        {
            this.Image = image;
            Image.Source = "add_image.png";
            this.AddReview = addReview;
            SubmitReview = new Command(SubmitReviewAction);
        }

        public void SubmitReviewAction()
        {
            this.AddReview(this.Image, this.Description);
        }

        public void ChangeImage(string base64Text)
        {
            Image.Source = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(base64Text)));
            OnPropertyChanged(nameof(Image));
        }
    }
}
