using BulgarianPlaces.Models;
using BulgarianPlaces.Views;
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

        public ProfileViewModel()
        {
            Title = "Profile";
            client = new HttpClient();

            Task.Run(async () =>
            {
                try
                {
                    Uri uri = new Uri(string.Format("http://192.168.1.6:44393/Review/Admin", string.Empty));
                    var result = await client.GetAsync(uri);
                    Console.WriteLine(result);
                }catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }).Wait();

        }
    }
}
