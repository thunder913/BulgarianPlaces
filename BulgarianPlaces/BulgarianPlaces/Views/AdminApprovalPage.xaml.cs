using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace BulgarianPlaces.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminApprovalPage : ContentPage
    {
        public bool IsAtThePlace { get; set; } = true;
        public AdminApprovalPage()
        {
            InitializeComponent();
            BindingContext = this;
            var position = new Position(42.7249925, 25.4833039);
            MyMap.MoveToRegion(new MapSpan(position, 1, 1));
            MyMap.Pins.Add(new Pin
            {
                Label = "Location",
                Position = new Position(42.7249925, 25.4833039),
            });
            MyMap.Pins.Add(new Pin
            {
                Label = "Added from",
                Position = new Position(42.7229925, 25.4133039),
            });
        }
    }
}