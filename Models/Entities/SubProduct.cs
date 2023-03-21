namespace Models.Entities;

public sealed class SubProduct
{
    public long Id { get; set; }
    public decimal Price { get; set; }
    public long Quantity { get; set; }
    
    public Product Product { get; set; }
    public ICollection<SubProductParameterValue> SubProductAttributeValue { get; set; }
}