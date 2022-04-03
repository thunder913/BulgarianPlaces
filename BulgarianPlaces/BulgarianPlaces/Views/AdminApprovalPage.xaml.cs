using BulgarianPlaces.ViewModels;
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
        public AdminApprovalViewModel vm { get; set; }
        public AdminApprovalPage()
        {
            InitializeComponent();
            BindingContext = vm = new AdminApprovalViewModel(MyMap);
            Title = "Request Approval";
        }
    }
}