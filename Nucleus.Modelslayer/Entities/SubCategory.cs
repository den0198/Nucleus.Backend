namespace Nucleus.ModelsLayer.Entities;

public sealed class SubCategory : IEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime DateTimeCreated { get; set; }
    public DateTime DateTimeModified { get; set; }

    public long CategoryId { get; set; }
    public Category Category { get; set; }
    public IEnumerable<Product> Products { get; set; }
}