﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BulgarianPlaces.Views.Ranking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllTimeRankingPage : ContentPage
    {
        public AllTimeRankingPage()
        {
            InitializeComponent();
            Title = "Ranking";
        }
    }
}