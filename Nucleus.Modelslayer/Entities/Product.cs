namespace Nucleus.ModelsLayer.Entities;

public class Product : IEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime DateTimeCreated { get; set; }
    public DateTime DateTimeModified { get; set; }
    
    public long CategoryId { get; set; }
    public Category Category { get; set; }
    public virtual ICollection<Parameter> Parameters { get; set; }
    public virtual ICollection<SubProduct> SubProducts { get; set; }
    public virtual ICollection<AddOn> AddOns { get; set; }
}