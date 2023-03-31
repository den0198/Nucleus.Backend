using NucleusModels.GraphQl.Data.SubData;

namespace NucleusModels.GraphQl.Data;

public sealed class GetMixSubProductsAtNewProductData
{
    public IList<MixedSubProductSubData> SubProducts { get; init; }
}