using System.Collections.Generic;

namespace BulgarianPlaces.Models.HttpModels
{
    public class ProfileDto
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Visited { get; set; }
        public int VisitedLastMonth { get; set; }
        public ICollection<ProfilePlaceVisitedDto> PlacesVisited { get; set; } = new List<ProfilePlaceVisitedDto>();
    }
}
