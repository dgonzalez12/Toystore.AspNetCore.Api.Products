using Toystore.Core.Products.Definition;

namespace Toystore.AspNetCore.Api.Products.Definition
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? MinimumAge { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
