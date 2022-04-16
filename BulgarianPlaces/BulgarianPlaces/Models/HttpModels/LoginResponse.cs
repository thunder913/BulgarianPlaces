namespace BulgarianPlaces.Models.HttpModels
{
    public class LoginResponse
    {
        public string Message { get; set; }
        public string Email { get; set; }
        public string JwtToken { get; set; }
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public bool HasCompletedFirstTime { get; set; }
    }
}
