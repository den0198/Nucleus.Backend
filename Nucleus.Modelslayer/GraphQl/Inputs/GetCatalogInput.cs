namespace Nucleus.ModelsLayer.GraphQl.Inputs;

public sealed class GetCatalogInput
{
    public long? CategoryId { get; init; }
    
    public long? StoreId { get; init; }

    public int? ProductSortId { get; init; }
    
    public long? FirstProduct { get; init; }
    
    public int? CountProducts { get; init; }

}