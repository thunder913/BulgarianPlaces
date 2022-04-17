using BulgarianPlaces.Views;
using System;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BulgarianPlaces.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public HttpClient client = new HttpClient();
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public Command RegisterCommand { get; }
        public Command SignInCommand { get; }
        public Func<string, Task> DisplayAlert;
        public RegisterViewModel(Func<string, Task> displayAlert)
        {
            this.DisplayAlert = displayAlert;
            this.RegisterCommand = new Command(OnRegisterClicked);
            this.SignInCommand = new Command(OnSignInClicked);
        }
        private async void OnRegisterClicked(object obj)
        {
            if(string.IsNullOrWhiteSpace(this.Email) || !Regex.IsMatch(this.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                await this.DisplayAlert("Въвел си невалиден имейл!");
                return;
            }
            else if (this.Password != this.ConfirmPassword)
            {
                await this.DisplayAlert("Паролите не са еднакви!");
                return;
            }
            else if (string.IsNullOrWhiteSpace(this.Password) || this.Password.Length < 6)
            {
                await this.DisplayAlert("Паролата трябва да е дълга поне 6 символа!");
                return;
            }

            Uri uri = new Uri(string.Format(GlobalConstants.Url + $"User/register?email={this.Email}&password={this.Password}"));
            var result = await client.PostAsync(uri, null);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                await this.DisplayAlert("Вече има регистриран потребител с този имейл. Опитай отново!");
                return;
            }
            var id = int.Parse(await result.Content.ReadAsStringAsync());
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        private async void OnSignInClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
