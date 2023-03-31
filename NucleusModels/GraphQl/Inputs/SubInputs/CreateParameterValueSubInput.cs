using System.ComponentModel.DataAnnotations;
using HotChocolate.Types;

namespace NucleusModels.GraphQl.Inputs.SubInputs;

public sealed class CreateParameterValueSubInput
{
    [Required]
    public string Value { get; set; }
}

public sealed class CreateParameterValueSubInputType : CoreType<CreateParameterValueSubInput>
{
    protected override void Configure(IObjectTypeDescriptor<CreateParameterValueSubInput> descriptor)
    {
        base.Configure(descriptor);
        
        descriptor
            .Field(nti => nti.Value)
            .Name("value")
            .Type<StringType>();
    }
}