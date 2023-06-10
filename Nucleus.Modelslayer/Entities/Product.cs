namespace Nucleus.ModelsLayer.Entities;

public sealed class Product : IEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime DateTimeCreated { get; set; }
    public DateTime DateTimeModified { get; set; }
    
    public long CategoryId { get; set; }
    public Category Category { get; set; }
    public IEnumerable<Parameter> Parameters { get; set; }
    public IEnumerable<SubProduct> SubProducts { get; set; }
    public ICollection<AddOn> AddOns { get; set; }
}