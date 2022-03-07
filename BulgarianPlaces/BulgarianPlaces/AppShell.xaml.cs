using BulgarianPlaces.ViewModels;
using BulgarianPlaces.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BulgarianPlaces
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public bool IsLoggedIn { get; set; }
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));

            //IsLoggedIn = Request To Api to check whether user is logged in

            if (!this.IsLoggedIn)
            {
                Task.Run(async () =>
                {
                    await Shell.Current.GoToAsync("//RegisterPage");
                });
                SetTabBarIsVisible(this, false);
            }
            else
            {
                SetTabBarIsVisible(this, true);
            }
        }



    }
}
