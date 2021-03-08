namespace Toystore.AspNetCore.Api.Products.Persistence
{
    public interface IProductContextConfiguration
    {
        string DatabaseName { get; set; }
    }
}
