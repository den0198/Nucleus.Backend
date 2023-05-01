using System.ComponentModel.DataAnnotations;
using HotChocolate.Types;
using Nucleus.ModelsLayer.GraphQl.Inputs.SubInputs;

namespace Nucleus.ModelsLayer.GraphQl.Inputs;

public sealed class CreateProductInput
{
    [Required]
    public string Name { get; set; }

    [Required] 
    public long CategoryId { get; set; }

    [Required]
    public IList<CreateParameterSubInput> Parameters { get; set; }

    [Required] 
    public IList<CreateAddOnSubInput> AddOns { get; set; }
}

public sealed class CreateProductInputType : CoreType<CreateProductInput>
{
    protected override void Configure(IObjectTypeDescriptor<CreateProductInput> descriptor)
    {
        base.Configure(descriptor);
        
        descriptor
            .Field(nti => nti.Name)
            .Name("name")
            .Type<StringType>();
        
        descriptor
            .Field(nti => nti.CategoryId)
            .Name("categoryId")
            .Type<LongType>();

        descriptor
            .Field(nti => nti.Parameters)
            .Name("parameters")
            .Type<ListType<CreateParameterSubInputType>>();
        
        descriptor
            .Field(nti => nti.AddOns)
            .Name("addons")
            .Type<ListType<CreateAddOnSubInputType>>();
    }
}