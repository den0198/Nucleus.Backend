namespace Models.Entities;

public sealed class ParameterValue
{
    public long Id { get; set; }
    public string Value { get; set; }
    
    public Parameter Parameter { get; set; }
    public ICollection<SubProductParameterValue> SubProductParameterValues { get; set; }
}