namespace BulgarianPlaces.Models
{
    public class PlaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public string Image { get; set; }
        public decimal Rating { get; set; }
        public int Visits { get; set; }
        public string RatingString => Rating.ToString("0.00") + "/5.00";
    }
}
