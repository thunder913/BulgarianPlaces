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
            People.Add(new Person() { Number=1 ,Name = "Pesho Petrov", Image = "https://scontent.fsof8-1.fna.fbcdn.net/v/t1.6435-9/194957949_4334439429940720_5542816028295677772_n.jpg?_nc_cat=108&ccb=1-5&_nc_sid=09cbfe&_nc_ohc=o809HTUl7LIAX-TTwzJ&_nc_ht=scontent.fsof8-1.fna&oh=00_AT9tYtVYtMZSgigPmYPzxZvVZzRQHSZU03rGxf4RUwOl1g&oe=6250D054", Id="1235-52" });
            People.Add(new Person() { Number=2, Name = "Gosho Goshov", Image = "https://scontent.fsof8-1.fna.fbcdn.net/v/t39.30808-6/238783365_1432028623838190_1922502318663660868_n.jpg?_nc_cat=111&ccb=1-5&_nc_sid=730e14&_nc_ohc=_4Esvl7pj5MAX8XMQk4&_nc_ht=scontent.fsof8-1.fna&oh=00_AT9rstfnV17dttFg11tIzEDy87qMQARvkharGhCU65brWA&oe=622EF74A", Id = "3235-51" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "xamarin_logo.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "xamarin_logo.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "xamarin_logo.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "xamarin_logo.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "xamarin_logo.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "xamarin_logo.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "xamarin_logo.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "xamarin_logo.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "xamarin_logo.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "xamarin_logo.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "xamarin_logo.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "xamarin_logo.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "xamarin_logo.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "xamarin_logo.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "xamarin_logo.png", Id = "6235-53" });
            People.Add(new Person() { Number=3, Name = "Ivan Ivanov", Image = "xamarin_logo.png", Id = "6235-53" });
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