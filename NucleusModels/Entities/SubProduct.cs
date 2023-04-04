namespace NucleusModels.Entities;

public class SubProduct : IEntity
{
    public long Id { get; set; }
    public decimal Price { get; set; }
    public long Quantity { get; set; }
    public DateTime DateTimeCreated { get; set; }
    public DateTime DateTimeModified { get; set; }
    
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public virtual ICollection<SubProductParameterValue> SubProductParameterValues { get; set; }
}