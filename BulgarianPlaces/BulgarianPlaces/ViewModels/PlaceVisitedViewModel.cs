using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace BulgarianPlaces.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class PlaceVisitedViewModel : BaseViewModel
    {
        private string text;
        private string description;
        private int id;
        public int Id
        {
            get => id; 
            set
            {
                this.id = value;
                this.LoadItemId(value);
            }
        }

        public string Text
        {
            get => text;
            set
            {
                SetProperty(ref text, value);
            }
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public void LoadItemId(int id)
        {
            try
            {
                Text = "TOVA E TEXT" + id;
                Description = "tui e description" + id;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
