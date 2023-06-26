namespace Nucleus.ModelsLayer.Entities;

public sealed class Store : IEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime DateTimeCreated { get; set; }
    public DateTime DateTimeModified { get; set; }

    public long SellerId { get; set; }
    public Seller Seller { get; set; }
    public IEnumerable<Product> Products { get; set; }
}