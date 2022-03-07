using BulgarianPlaces.Views;
using Xamarin.Forms;

namespace BulgarianPlaces.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public Command RegisterCommand { get; }

        public RegisterViewModel()
        {
            this.RegisterCommand = new Command(OnRegisterClicked);
        }
        private async void OnRegisterClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
