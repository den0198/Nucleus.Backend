using System.ComponentModel.DataAnnotations;
using HotChocolate.Types;
using NucleusModels.GraphQl.SubInputs;

namespace NucleusModels.GraphQl.Inputs;

public sealed class CreateProductInput
{
    [Required]
    public string Name { get; set; }

    [Required]
    public List<CreateParameterSubInput> Parameters { get; set; }
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
            .Field(nti => nti.Parameters)
            .Name("parameters")
            .Type<ListType<CreateParameterSubInputType>>();
    }
}