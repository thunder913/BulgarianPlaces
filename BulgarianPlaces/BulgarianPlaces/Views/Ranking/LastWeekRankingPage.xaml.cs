using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BulgarianPlaces.Views.Ranking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LastWeekRanking : ContentPage
    {
        public ObservableCollection<Person> People { get; set; } = new ObservableCollection<Person>();
        public LastWeekRanking()
        {
            InitializeComponent();

            PeopleView.ItemsSource = People;

            Title = "Ranking";
            People.Add(new Person() { Name = "Pesho", Image = "sign.png" });
            People.Add(new Person() { Name = "Gosho", Image = "sign.png" });
            People.Add(new Person() { Name = "Ivan", Image = "sign.png" });
        }
    }

    public class Person
    {
        public string Image { get; set; }
        public string Name { get; set; }
    }
}