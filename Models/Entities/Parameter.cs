namespace Models.Entities;

public sealed class Parameter
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public Product Product { get; set; }
    public ICollection<ParameterValue> ParameterValues { get; set; }
    public ICollection<SubProductParameterValue> SubProductParameterValues { get; set; }
}