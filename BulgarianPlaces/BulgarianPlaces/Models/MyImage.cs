using System;
using Xamarin.Forms;

namespace BulgarianPlaces.Models
{
    public class MyImage : Image
    {
        public Func<byte[]> GetBytes { get; set; }
    }
}
