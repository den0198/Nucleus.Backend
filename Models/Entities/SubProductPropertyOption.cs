namespace Models.Entities;

public class SubProductPropertyOption
{
    public long SubProductPropertyOptionId { get; set; }
    
    public SubProduct SubProduct { get; set; }
    public Property Property { get; set; }
    public Option Option { get; set; }
}