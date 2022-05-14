using BulgarianPlaces.Models.HttpModels;
using BulgarianPlaces.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BulgarianPlaces.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public HttpClient client = new HttpClient();
        public string Email { get; set; }
        public string Password { get; set; }
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }
        public Func<string, Task> DisplayAlert;
        public LoginViewModel(Func<string, Task> displayAlert)
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(GoToRegister);
            this.DisplayAlert = displayAlert;
        }

        private async void OnLoginClicked(object obj)
        {
            Application.Current.Properties.TryGetValue("token", out var token);
            if (string.IsNullOrWhiteSpace(this.Email) || !Regex.IsMatch(this.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                await this.DisplayAlert("Въвел си неправилен имейл!");
                return;
            }
            else if (string.IsNullOrWhiteSpace(this.Password) || this.Password.Length < 6)
            {
                await this.DisplayAlert("Паролата трябва да е дълга поне 6 символа");
                return;
            }
            Uri uri = new Uri(string.Format(GlobalConstants.Url + $"User/login?email={this.Email}&password={this.Password}"));
            var result = await client.PostAsync(uri, null);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                await this.DisplayAlert("Не съществува потребител със зададените имейл и парола!");
                return;
            }
            var response = await result.Content.ReadAsStringAsync();
            var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(response);
            Application.Current.Properties["token"] = loginResponse.JwtToken;
            Application.Current.Properties["id"] = loginResponse.Id;
            Application.Current.Properties["isAdmin"] = loginResponse.IsAdmin;
            AppShell.IsAdmin = loginResponse.IsAdmin;

            if (loginResponse.IsAdmin)
            {
                if (AppShell.RootTab.Items.Count != 4)
                {
                    AppShell.RootTab.Items.Insert(2, new Tab()
                    {
                        Title = "Админ",
                        Icon = "admin.png",
                        Items =
                    {
                        new ShellContent()
                        {
                            Route = "AdminPage",
                            ContentTemplate = new DataTemplate(typeof(AdminPage))
                        }
                    }
                    });
                }
            }
            else
            {
                if (AppShell.RootTab.Items.Count == 4)
                {
                    AppShell.RootTab.Items.RemoveAt(2);
                }
            }
            await Application.Current.SavePropertiesAsync();
            if (!loginResponse.HasCompletedFirstTime)
            {
                await Shell.Current.GoToAsync($"/{nameof(FirstTimePage)}");
            }
            else
            {
                await Shell.Current.GoToAsync($"//{nameof(ProfilePage)}");
            }
        }

        private async void GoToRegister(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
        }
    }
}
