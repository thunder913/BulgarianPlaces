using System;
using System.Collections.Generic;
using System.Text;

namespace BulgarianPlaces.Models.HttpModels
{
    public class ProfilePlaceVisitedDto
    {
        public string PlaceName { get; set; }
        public int Rating { get; set; }
        public string Date { get; set; }
        public int Id { get; set; }
    }
}
