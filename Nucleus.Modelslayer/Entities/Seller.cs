namespace Nucleus.ModelsLayer.Entities;

public sealed class Seller : IEntity
{
    public long Id { get; set; } 
    public DateTime DateTimeCreated { get; set; }
    public DateTime DateTimeModified { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
    public IEnumerable<Store> Stores { get; set; }
}