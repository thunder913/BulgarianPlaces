using BulgarianPlaces.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulgarianPlaces.Models
{
    public class SearchResult
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int LastColumnValue { get; set; }
        public SearchResultType SearchType { get; set; }
    }
}
