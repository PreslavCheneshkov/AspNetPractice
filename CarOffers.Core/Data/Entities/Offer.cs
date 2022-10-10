using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOffers.Core.Data.Entities
{
    public class Offer
    {
        [Key]
        public Guid Id { get; set; }
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
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        [StringLength(500)]
        public string PictureUrl { get; set; } = null!;
    }
}
