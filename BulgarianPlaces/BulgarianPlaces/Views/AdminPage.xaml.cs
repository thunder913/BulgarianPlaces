using BulgarianPlaces.Models.HttpModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BulgarianPlaces.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminPage : ContentPage
    {
        private HttpClient client { get; set; }
        public ObservableCollection<AdminPanelDto> Submits { get; set; } = new ObservableCollection<AdminPanelDto>();
        public AdminPage()
        {
            client = new HttpClient();
            InitializeComponent();
            BindingContext = this;
        }
        private void SubmitsView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = (AdminPanelDto)((ListView)sender).SelectedItem;
            Shell.Current.GoToAsync($"//AdminPage/{nameof(AdminApprovalPage)}?Id="+selectedItem.Id);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Submits.Clear();
            Task.Run(async () =>
            {
                Uri uri = new Uri(string.Format(GlobalConstants.Url + "Review/Admin/"));
                var result = await client.GetAsync(uri);
                var responseAsString = await result.Content.ReadAsStringAsync();
                var items = JsonConvert.DeserializeObject<List<AdminPanelDto>>(responseAsString);
                foreach (var item in items)
                {
                    Submits.Add(item);
                }
            }).Wait();
        }
    }
}