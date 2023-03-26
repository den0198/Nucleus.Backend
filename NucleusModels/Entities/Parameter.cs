namespace NucleusModels.Entities;

public class Parameter
{
    public long Id { get; set; }
    public string Name { get; set; }

    public long ProductId { get; set; }
    public Product Product { get; set; }
    public virtual ICollection<ParameterValue> ParameterValues { get; set; }
    public virtual ICollection<SubProductParameterValue> SubProductParameterValues { get; set; }
}