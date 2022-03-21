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
    class ProfileViewModel : BaseViewModel
    {
        HttpClient client;
        public ProfileDto Profile { get; set; }
        public ProfileViewModel()
        {
            Title = "Profile";
            client = new HttpClient();

            Task.Run(async () =>
            {
                try
                {
                    Uri uri = new Uri(string.Format("http://10.0.2.2:61650/User/Profile/1"));
                    var result = await client.GetAsync(uri);
                    var responseAsString = await result.Content.ReadAsStringAsync();
                    Profile = JsonConvert.DeserializeObject<ProfileDto>(responseAsString);
                }catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }).Wait();

        }
    }
}
