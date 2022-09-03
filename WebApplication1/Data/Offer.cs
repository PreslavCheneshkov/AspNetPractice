using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [StringLength(50)]
        public string Manufacturer { get; set; }
        [StringLength (50)]
        public string Model { get; set; }
        [Range(1000, 500_000)]
        public decimal Price { get; set; }
    }
}
