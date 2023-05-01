namespace Nucleus.ModelsLayer.Entities;

public class ParameterValue : IEntity
{
    public long Id { get; set; }
    public string Value { get; set; }
    public DateTime DateTimeCreated { get; set; }
    public DateTime DateTimeModified { get; set; }
    
    public long ParameterId { get; set; }
    public Parameter Parameter { get; set; }
    public virtual ICollection<SubProductParameterValue> SubProductParameterValues { get; set; }
}