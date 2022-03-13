using System;
using System.Collections.Generic;
using System.Text;

namespace BulgarianPlaces.Models
{
    public class ProfilePlace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Date { get; set; }
        public string RatingString => this.Rating.ToString() + "/5";
    }
}
