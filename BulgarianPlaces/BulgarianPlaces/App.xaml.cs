using BulgarianPlaces.Services;
using BulgarianPlaces.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BulgarianPlaces
{
    public partial class App : Application
    {
        public bool IsLoggedIn { get; set; }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();

            DependencyService.Register<MockDataStore>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
