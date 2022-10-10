using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOffers.Core.Models
{
    public class SearchInputModel
    {
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }
        public int? ToMileage { get; set; }
        public decimal? FromPrice { get; set; }
        public decimal? ToPrice { get; set; }
    }
}
