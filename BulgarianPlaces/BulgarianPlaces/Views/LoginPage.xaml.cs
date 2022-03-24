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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel(DisplayAlert);
            Shell.SetTabBarIsVisible(this, false);
        }
        public async Task DisplayAlert(string text)
        {
            await this.DisplayAlert("Error", text, "OK");
        }
    }
}