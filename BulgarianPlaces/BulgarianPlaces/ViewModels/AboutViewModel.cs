using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BulgarianPlaces.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public string Ivan { get; set; }
        public AboutViewModel()
        {
            Title = "About11";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            SetIvan();
        }

        public void SetIvan()
        {
            this.Ivan = "Bai Ivan";
        }

        public ICommand OpenWebCommand { get; }
    }
}