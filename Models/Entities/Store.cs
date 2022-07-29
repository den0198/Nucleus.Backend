namespace Models.Entities;

public class Store
{
    public long StoreId { get; set; }
    public string Name { get; set; }

    public User Owner { get; set; }
    public ICollection<Product> Products { get; set; }
}