namespace Models.Entities;

public sealed class Product
{
    public long Id { get; set; }
    public string Name { get; set; }

    public Catalog Catalog { get; set; }
    public ICollection<Parameter> Parameters { get; set; }
    public ICollection<SubProduct> SubProducts { get; set; }
    public ICollection<AddOn> AddOns { get; set; }
}