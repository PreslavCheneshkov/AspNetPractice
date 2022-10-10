using System.ComponentModel.DataAnnotations;

namespace CarOffers.Models
{
    public class OfferInputModel
    {
        [Required]
        [StringLength(50)]
        public string Manufacturer { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Model { get; set; } = null!;
        [Range(0, int.MaxValue)]
        public int Mileage { get; set; }
        [Range(1940, 2100)]
        public int Year { get; set; }
    }
}
