using System.ComponentModel.DataAnnotations;
using HotChocolate.Types;

namespace NucleusModels.GraphQl.Inputs.SubInputs;

public sealed class UpdateSubProductSubInput
{
    [Required]
    public long Id { get; init; }
    
    [Required]
    public decimal Price { get; init; }
    
    [Required]
    public long Quantity { get; init; }
}

public sealed class UpdateSubProductSubInputType : CoreType<UpdateSubProductSubInput>
{
    protected override void Configure(IObjectTypeDescriptor<UpdateSubProductSubInput> descriptor)
    {
        base.Configure(descriptor);
        
        descriptor
            .Field(nti => nti.Id)
            .Name("id")
            .Type<LongType>();
        
        descriptor
            .Field(nti => nti.Price)
            .Name("price")
            .Type<DecimalType>();
        
        descriptor
            .Field(nti => nti.Quantity)
            .Name("quantity")
            .Type<LongType>();
    }
}