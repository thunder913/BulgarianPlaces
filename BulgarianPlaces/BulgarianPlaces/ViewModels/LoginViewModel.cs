using BulgarianPlaces.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BulgarianPlaces.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(GoToRegister);
        }

        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        private async void GoToRegister(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
        }
    }
}
