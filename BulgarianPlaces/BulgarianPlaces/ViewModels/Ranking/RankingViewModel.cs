using BulgarianPlaces.Views;
using Xamarin.Forms;

namespace BulgarianPlaces.ViewModels.Ranking
{
    public class RankingViewModel : BaseViewModel
    {
        public Command AddNewReview { get; }

        public RankingViewModel()
        {
            AddNewReview = new Command(OnAddNewReview);
        }

        public async void OnAddNewReview()
        {
            await Shell.Current.GoToAsync($"//LastWeekRankingPage/{nameof(AddReviewPage)}");
        }
    }
}
