namespace Models.Entities;

public class ParameterValue
{
    public long Id { get; set; }
    public string Value { get; set; }
    
    public long ParameterId { get; set; }
    public Parameter Parameter { get; set; }
    public virtual ICollection<SubProductParameterValue> SubProductParameterValues { get; set; }
}