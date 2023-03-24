namespace Models.Entities;

public class SubProduct
{
    public long Id { get; set; }
    public decimal Price { get; set; }
    public long Quantity { get; set; }
    
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public virtual ICollection<SubProductParameterValue> SubProductParameterValues { get; set; }
}