namespace Models.Entities;

public sealed class SubProductParameterValue
{
    public long Id { get; set; }
    
    public SubProduct SubProduct { get; set; }
    public Parameter Parameter { get; set; }
    public ParameterValue ParameterValue { get; set; }
}