namespace Nucleus.ModelsLayer.Entities;

public sealed class SubProductParameterValue : IEntity
{
    public long SubProductId { get; set; }
    public long ParameterId { get; set; }
    public long ParameterValueId { get; set; }
    
    public DateTime DateTimeCreated { get; set; }
    public DateTime DateTimeModified { get; set; }
    
    public SubProduct SubProduct { get; set; }
    public Parameter Parameter { get; set; }
    public ParameterValue ParameterValue { get; set; }
}