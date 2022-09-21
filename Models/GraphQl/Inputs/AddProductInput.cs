using System.ComponentModel.DataAnnotations;
using Common.GraphQl;
using HotChocolate.Types;
using Models.GraphQl.Inputs.SubInputs;

namespace Models.GraphQl.Inputs;

public sealed class AddProductInput
{
    [Required]
    public IEnumerable<string> Name { get; init; }
    
    [Required]
    public decimal Price { get; init; }
    
    [Required]
    public IEnumerable<PropertySubInput> Properties { get; init; }
}

public sealed class AddProductInputType : CoreType<AddProductInput>
{
    protected override void Configure(IObjectTypeDescriptor<AddProductInput> descriptor)
    {
        base.Configure(descriptor);

        descriptor
            .Field(api => api.Name)
            .Name("name")
            .Type<StringType>();

        descriptor
            .Field(api => api.Price)
            .Name("price")
            .Type<DecimalType>();
        
        descriptor
            .Field(api => api.Properties)
            .Name("properties")
            .Type<ListType<PropertySubInputType>>();
    }
}