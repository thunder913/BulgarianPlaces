using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BulgarianPlaces.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminPage : ContentPage
    {
        public ObservableCollection<SubmitList> Submits { get; set; } = new ObservableCollection<SubmitList>();
        public AdminPage()
        {
            InitializeComponent();
            BindingContext = this;
            Submits.Add(new SubmitList() { DateSubmitted = "12/03/2022", Email = "andon_00@abv.bg"});
            Submits.Add(new SubmitList() { DateSubmitted = "12/03/2022", Email = "andon_00@abv.bg"});
            Submits.Add(new SubmitList() { DateSubmitted = "12/03/2022", Email = "andon_00@abv.bg"});
            Submits.Add(new SubmitList() { DateSubmitted = "12/03/2022", Email = "andon_00@abv.bg"});
            Submits.Add(new SubmitList() { DateSubmitted = "12/03/2022", Email = "andon_00@abv.bg"});
            Submits.Add(new SubmitList() { DateSubmitted = "12/03/2022", Email = "andon_00@abv.bg"});
            Submits.Add(new SubmitList() { DateSubmitted = "12/03/2022", Email = "andon_00@abv.bg"});
            Submits.Add(new SubmitList() { DateSubmitted = "12/03/2022", Email = "andon_00@abv.bg"});
        }
        private void SubmitsView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Shell.Current.GoToAsync($"{nameof(AdminApprovalPage)}");
        }

        public class SubmitList
        {
            public string Email { get; set; }
            public string DateSubmitted { get; set; }
        }
    }
}