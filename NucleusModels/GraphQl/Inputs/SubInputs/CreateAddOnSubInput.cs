using System.ComponentModel.DataAnnotations;
using HotChocolate.Types;

namespace NucleusModels.GraphQl.Inputs.SubInputs;

public sealed class CreateAddOnSubInput
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public decimal Price { get; set; }
    
    [Required]
    public long Quantity { get; set; }
}

public sealed class CreateAddOnSubInputType : CoreType<CreateAddOnSubInput>
{
    protected override void Configure(IObjectTypeDescriptor<CreateAddOnSubInput> descriptor)
    {
        base.Configure(descriptor);
        
        descriptor
            .Field(nti => nti.Name)
            .Name("name")
            .Type<StringType>();
        
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