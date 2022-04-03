using BulgarianPlaces.Models;
using BulgarianPlaces.Models.HttpModels;
using BulgarianPlaces.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BulgarianPlaces.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class ProfileViewModel : BaseViewModel
    {
        public bool ShowSignOut { get; set; }
        public int? UserId { get; set; }
        private string id;
        public string Id
        {
            get => id;
            set
            {
                this.id = value;
                if (int.TryParse(value, out int res))
                {
                    UserId = res;
                }
                SetUserProfile();
            }
        }
        HttpClient client;
        public ProfileDto Profile { get; set; }
        public ProfileViewModel(bool setDefaultProfile)
        {
            Title = "Profile";
            client = new HttpClient();
            if (setDefaultProfile)
            {
                SetUserProfile();
            }
        }

        private void SetUserProfile()
        {
            if (UserId == null)
            {
                Task.Run(async () =>
                {
                    try
                    {
                        Application.Current.Properties.TryGetValue("id", out var id);
                        Uri uri = new Uri(string.Format(GlobalConstants.Url + "User/Profile/" + id));
                        var result = await client.GetAsync(uri);
                        var responseAsString = await result.Content.ReadAsStringAsync();
                        Profile = JsonConvert.DeserializeObject<ProfileDto>(responseAsString);
                        ShowSignOut = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                }).Wait();
            }
            else
            {
                Task.Run(async () =>
                {
                    try
                    {
                        Uri uri = new Uri(string.Format(GlobalConstants.Url + "User/Profile/" + UserId));
                        var result = await client.GetAsync(uri);
                        var responseAsString = await result.Content.ReadAsStringAsync();
                        Profile = JsonConvert.DeserializeObject<ProfileDto>(responseAsString);
                        ShowSignOut = false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                }).Wait();
            }
            OnPropertyChanged(nameof(Profile));
            OnPropertyChanged(nameof(ShowSignOut));
        }
    }
}
