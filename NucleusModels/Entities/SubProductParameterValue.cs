namespace NucleusModels.Entities;

public class SubProductParameterValue : IEntity
{
    public long Id { get; set; }
    public DateTime DateTimeCreated { get; set; }
    public DateTime DateTimeModified { get; set; }
    
    public long SubProductId { get; set; }
    public SubProduct SubProduct { get; set; }
    public long ParameterId { get; set; }
    public Parameter Parameter { get; set; }
    public long ParameterValueId { get; set; }
    public ParameterValue ParameterValue { get; set; }
}