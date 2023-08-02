namespace Nucleus.ModelsLayer.SqlQueryResults;

public sealed class ProductInCatalog
{
    public long ProductId { get; set; }
    public string ProductName { get; set; }
    public ProductPriceInCatalog Price { get; set; }
}

public sealed class ProductPriceInCatalog
{
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }
}