namespace Models.Entities;

public sealed class AddOn
{
    public long Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public long Quantity { get; set; }
    
    public Product Product { get; set; }
}