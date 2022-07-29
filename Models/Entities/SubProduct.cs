namespace Models.Entities;

public class SubProduct
{
    public long SubProductId { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }

    public Product Product { get; set; }
    public ICollection<SubProductPropertyOption> PropertyOptions { get; set; }
}