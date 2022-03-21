using BulgarianPlaces.Handlers;
using BulgarianPlaces.ViewModels;
using BulgarianPlaces.Views;
using BulgarianPlaces.Views.Ranking;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BulgarianPlaces
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public static bool IsLoggedIn { get; set; } = true;
        public bool IsAdmin { get; set; } = true;
        public AppShell()
        {
            
            InitializeComponent();
            BindingContext = this;
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            Routing.RegisterRoute(nameof(PlaceVisitedPage), typeof(PlaceVisitedPage));
            Routing.RegisterRoute(nameof(AddReviewPage), typeof(AddReviewPage));
            Routing.RegisterRoute(nameof(AdminPage), typeof(AdminPage));
            Routing.RegisterRoute(nameof(AdminApprovalPage), typeof(AdminApprovalPage));
            Routing.RegisterRoute(nameof(ImagePage), typeof(ImagePage));

            //Ranking pages
            Routing.RegisterRoute(nameof(LastWeekRanking), typeof(LastWeekRanking));
            Routing.RegisterRoute(nameof(LastMonthRanking), typeof(LastMonthRanking));
            Routing.RegisterRoute(nameof(LastYearRanking), typeof(LastYearRanking));
            Routing.RegisterRoute(nameof(AllTimeRankingPage), typeof(AllTimeRankingPage));
            Routing.RegisterRoute(nameof(SearchPage), typeof(SearchPage));

            //TODO IsLoggedIn = Request To Api to check whether user is logged in

            if (true)
            {
                Thread.Sleep(2000);
                IsAdmin = true;
            }

            if (!IsLoggedIn)
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
