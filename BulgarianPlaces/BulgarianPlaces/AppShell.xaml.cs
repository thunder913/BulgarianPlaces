using BulgarianPlaces.Handlers;
using BulgarianPlaces.Models.HttpModels;
using BulgarianPlaces.ViewModels;
using BulgarianPlaces.Views;
using BulgarianPlaces.Views.Ranking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BulgarianPlaces
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public HttpClient client = new HttpClient();
        public static bool IsLoggedIn { get; set; } = false;
        public static bool IsAdmin { get; set; } = true;
        public static bool HasCompletedFirstTime { get; set; } = false;
        public static TabBar RootTab;
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
            Routing.RegisterRoute(nameof(PlacePage), typeof(PlacePage));
            Routing.RegisterRoute(nameof(FirstTimePage), typeof(FirstTimePage));

            //Ranking pages
            Routing.RegisterRoute(nameof(LastWeekRanking), typeof(LastWeekRanking));
            Routing.RegisterRoute(nameof(LastMonthRanking), typeof(LastMonthRanking));
            Routing.RegisterRoute(nameof(LastYearRanking), typeof(LastYearRanking));
            Routing.RegisterRoute(nameof(AllTimeRankingPage), typeof(AllTimeRankingPage));
            Routing.RegisterRoute(nameof(SearchPage), typeof(SearchPage));

            RootTab = AppTabBar;

            // Gets the token and checks whether it exists
            Application.Current.Properties.TryGetValue("token", out var token);
            if (token != null)
            {
                Task.Run(async () =>
                {
                    // Verifies the token is correct
                    Uri uri = new Uri(string.Format(GlobalConstants.Url + $"User/verifytoken?token={token}"));
                    var result = await client.PostAsync(uri, null);

                    // If everything is okay, we parse the response and add the admin tab if the user is admin
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        IsLoggedIn = true;
                        var response = await result.Content.ReadAsStringAsync();
                        var loginResponse = JsonConvert.DeserializeObject<VerifyTokenDto>(response);
                        HasCompletedFirstTime = loginResponse.HasCompletedFirstTime;
                        if (loginResponse.IsAdmin)
                        {
                            IsAdmin = true;
                            if (AppShell.RootTab.Items.Count != 4)
                            {
                                AppShell.RootTab.Items.Insert(2, new Tab()
                                {
                                    Title = "Admin",
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
                    }
                    else
                    {
                        Application.Current.Properties.Clear();
                        IsLoggedIn = false;
                    }
                }).Wait();
            }
            else
            {
                IsLoggedIn = false;
            }

            if (!IsLoggedIn)
            {
                Task.Run(async () =>
                {
                    await this.GoToAsync("//RegisterPage");
                }).Wait();
                SetTabBarIsVisible(this, false);
            }
            else
            {
                // If the user has not completed the first time login part, we show him the page
                if (!HasCompletedFirstTime)
                {
                    Task.Run(async () =>
                    {
                        await this.GoToAsync($"/{nameof(FirstTimePage)}");
                    }).Wait();
                }
                else
                {
                    SetTabBarIsVisible(this, true);
                }
            }

            if (!IsLoggedIn || !IsAdmin)
            {
                if (this.Items.Count == 4)
                {
                    this.Items.RemoveAt(2);
                }
            }
        }

        public void RemoveTab()
        {
            AppTabBar.Items.RemoveAt(1);
        }
    }
}
