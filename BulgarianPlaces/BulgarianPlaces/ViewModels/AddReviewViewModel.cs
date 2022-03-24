using BulgarianPlaces.Handlers;
using BulgarianPlaces.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace BulgarianPlaces.ViewModels
{
    public class AddReviewViewModel : BaseViewModel
    {
        public Image image { get; set; } = new Image();
        public string Description { get; set; }
        public Action<Image, string> AddReview;
        public Command SubmitReview { get; }
        public AddReviewViewModel(Action<Image, string> addReview)
        {
            image.Source = "add_image.png";
            this.AddReview = addReview;
            SubmitReview = new Command(SubmitReviewAction);
        }

        public void SubmitReviewAction()
        {
            this.AddReview(this.image, this.Description);
        }
    }
}
