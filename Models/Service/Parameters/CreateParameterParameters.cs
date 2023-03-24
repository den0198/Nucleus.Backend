namespace Models.Service.Parameters;

public sealed record CreateParameterParameters(
    string Name)
{
    public long ProductId { get; set; }
}