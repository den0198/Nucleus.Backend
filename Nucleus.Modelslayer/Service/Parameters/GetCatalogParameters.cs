namespace Nucleus.ModelsLayer.Service.Parameters;

public record GetCatalogParameters(
    long? CategoryId,
    long? StoreId,
    int? ProductSortId,
    long? FirstProduct,
    int? CountProducts );