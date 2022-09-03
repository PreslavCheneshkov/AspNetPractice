using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class OfferInputModel
    {
        public OfferInputModel(string picture, string manufacturer, string model, decimal price)
        {
            Picture = picture;
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
        }

        [Required]
        public string Picture { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Manufacturer { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]

        public string Model { get; set; }
        public decimal Price { get; set; }
    }
}
