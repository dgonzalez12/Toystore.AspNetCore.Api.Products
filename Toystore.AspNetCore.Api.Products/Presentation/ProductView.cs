using System.ComponentModel.DataAnnotations;

namespace Toystore.AspNetCore.Api.Products.Presentation
{
    public class ProductView
    {
        public int? Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [Range(0, 100)]
        public int? MinimumAge { get; set; }
        [Required]
        [MaxLength(50)]
        public string Company { get; set; }
        [Required]
        [Range(1, 1000)]
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
