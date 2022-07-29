namespace Models.Entities;

public class Property
{
    public long PropertyId { get; set; }
    public string Name { get; set; }
    
    public Product Product { get; set; }
    public ICollection<Option> Options { get; set; }
}