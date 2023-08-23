namespace Nucleus.ModelsLayer.Entities;

public sealed class Category : IEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime DateTimeCreated { get; set; }
    public DateTime DateTimeModified { get; set; }

    public long? RootCategoryId { get; set; }
    public IEnumerable<Category> SubCategories { get; set; }
    public Category RootCategory { get; set; }
    public IEnumerable<Product> Products { get; set; }
}