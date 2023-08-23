namespace Nucleus.ModelsLayer.SqlQueryResults;

public sealed class ProductInCatalog
{
    public long ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }
}