namespace Models.Entities;

public class SubProductParameterValue
{
    public long Id { get; set; }
    
    public long SubProductId { get; set; }
    public SubProduct SubProduct { get; set; }
    public long ParameterId { get; set; }
    public Parameter Parameter { get; set; }
    public long ParameterValueId { get; set; }
    public ParameterValue ParameterValue { get; set; }
}