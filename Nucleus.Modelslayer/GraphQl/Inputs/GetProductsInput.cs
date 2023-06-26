using System.ComponentModel.DataAnnotations;
using HotChocolate.Types;

namespace Nucleus.ModelsLayer.GraphQl.Inputs;

public sealed class GetProductsInput
{
    public long? CategoryId { get; init; }
    
    public int? ProductSortId { get; init; }
    
    [Required]
    public long FirstProduct { get; init; }
    
    [Required]
    public int CountProducts { get; init; }

}

public sealed class GetProductsInputType : CoreType<GetProductsInput>
{
    protected override void Configure(IObjectTypeDescriptor<GetProductsInput> descriptor)
    {
        base.Configure(descriptor);

        descriptor
            .Field(nti => nti.CategoryId)
            .Name("categoryId")
            .Type<LongType>();
        
        descriptor
            .Field(nti => nti.ProductSortId)
            .Name("productSortId")
            .Type<LongType>();
        
        descriptor
            .Field(nti => nti.FirstProduct)
            .Name("firstProduct")
            .Type<LongType>();
        
        descriptor
            .Field(nti => nti.CountProducts)
            .Name("countProducts")
            .Type<IntType>();
    }
}