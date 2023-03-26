using System.ComponentModel.DataAnnotations;
using HotChocolate.Types;

namespace NucleusModels.GraphQl.SubInputs;

public sealed class CreateParameterSubInput
{
    [Required]
    public string Name { get; set; }
}

public sealed class CreateParameterSubInputType : CoreType<CreateParameterSubInput>
{
    protected override void Configure(IObjectTypeDescriptor<CreateParameterSubInput> descriptor)
    {
        base.Configure(descriptor);
        
        descriptor
            .Field(nti => nti.Name)
            .Name("name")
            .Type<StringType>();
    }
}