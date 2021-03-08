namespace Toystore.Core.Products.Definition
{
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int? MinimumAge { get; set; }
        string Company { get; set; }
        decimal Price { get; set; }
        string Image { get; set; }
    }
}
