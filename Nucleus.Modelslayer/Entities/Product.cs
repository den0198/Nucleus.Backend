namespace Nucleus.ModelsLayer.Entities;

public sealed class Product : IEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public bool IsSale { get; set; }
    public long CountSale { get; set; }
    public long CountLike { get; set; }
    public long CountDislike { get; set; } 
    public DateTime DateTimeCreated { get; set; }
    public DateTime DateTimeModified { get; set; }

    public long StoreId { get; set; }
    public Store Store { get; set; }
    public long SubCategoryId { get; set; }
    public SubCategory SubCategory { get; set; }
    public IEnumerable<Parameter> Parameters { get; set; }
    public IEnumerable<SubProduct> SubProducts { get; set; }
    public ICollection<AddOn> AddOns { get; set; }
}