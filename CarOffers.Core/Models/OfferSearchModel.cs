using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOffers.Core.Models
{
    public class OfferSearchModel
    {
        public string? Manufacturer { get; set; } 
        public string? Model { get; set; } 
        public int? Mileage { get; set; }
        public int? Year { get; set; }
        public decimal? Price { get; set; }
        public string? PictureUrl { get; set; }
    }
}
