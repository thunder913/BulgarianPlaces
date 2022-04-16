using BulgarianPlaces.Handlers;
using BulgarianPlaces.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BulgarianPlaces.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstTimePage : ContentPage
    {
        public string ImageBase64 { get; set; }
        private FirstTimeViewModel vm { get; set; }
        public FirstTimePage()
        {
            InitializeComponent();
            BindingContext = vm = new FirstTimeViewModel(image);
        }

        async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {
            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                var bytes = new byte[stream.Length];
                await stream.ReadAsync(bytes, 0, (int)stream.Length);
                ImageBase64 = Convert.ToBase64String(bytes);
                vm.ChangeImage(ImageBase64);
            }
        }
    }
}