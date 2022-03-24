using BulgarianPlaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BulgarianPlaces.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            this.BindingContext = new RegisterViewModel(DisplayAlert);
            Shell.SetTabBarIsVisible(this, false);
        }

        public async Task DisplayAlert(string text)
        {
            await this.DisplayAlert("Error", text, "OK");
        }
    }
}