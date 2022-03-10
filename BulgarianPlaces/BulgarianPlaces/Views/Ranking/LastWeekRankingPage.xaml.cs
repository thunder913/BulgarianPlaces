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
            People.Add(new Person() { Number=1 ,Name = "Pesho Petrov", Image = "sign.png", Id="1235-52" });
            People.Add(new Person() { Number=2, Name = "Gosho Goshov", Image = "sign.png", Id = "3235-51" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "sign.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "sign.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "sign.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "sign.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "sign.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "sign.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "sign.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "sign.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "sign.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "sign.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "sign.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "sign.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "sign.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "sign.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "sign.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "sign.png", Id = "6235-53" });
        }

        private void PeopleView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = ((ListView)sender).SelectedItem;
            //TODO redirect to profile page
        }
    }

    public class Person
    {
        public int Number { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
    }
}