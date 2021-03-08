namespace Toystore.AspNetCore.Api.Products.Persistence
{
    public class ProductContextConfiguration : IProductContextConfiguration
    {
        public string DatabaseName { get => databaseName; set => databaseName = value; }
        private string databaseName = "ToystoreDatabase";
    }
}
