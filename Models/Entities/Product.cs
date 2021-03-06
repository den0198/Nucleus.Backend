namespace Models.Entities;

public class Product
{
    public long ProductId { get; set; }
    public string Name { get; set; }

    public Store Store { get; set; }
    public ICollection<SubProduct> SubProducts { get; set; }
    public ICollection<Property> Properties { get; set; }
}