namespace Models.Entities;

public sealed class Catalog
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<Product> Products { get; set; }
}