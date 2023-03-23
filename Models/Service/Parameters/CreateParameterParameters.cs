using Models.Entities;

namespace Models.Service.Parameters;

public sealed record CreateParameterParameters(
    string Name)
{
    public Product Product { get; set; }
}