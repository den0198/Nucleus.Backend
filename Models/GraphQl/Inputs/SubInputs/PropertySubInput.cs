using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Common.GraphQl;
using HotChocolate.Types;

namespace Models.GraphQl.Inputs.SubInputs;

public sealed class PropertySubInput
{
    [Required]
    public string Name { get; init; }
    
    [Required]
    public IEnumerable<OptionSubInput> Options { get; init; }
}

public sealed class PropertySubInputType : CoreType<PropertySubInput>
{
    protected override void Configure(IObjectTypeDescriptor<PropertySubInput> descriptor)
    {
        base.Configure(descriptor);

        descriptor
            .Field(psi => psi.Name)
            .Name("name")
            .Type<StringType>();
        
        descriptor
            .Field(psi => psi.Options)
            .Name("options")
            .Type<OptionSubInputType>();
    }
}