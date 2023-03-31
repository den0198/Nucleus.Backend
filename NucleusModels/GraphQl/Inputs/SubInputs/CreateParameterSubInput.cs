using System.ComponentModel.DataAnnotations;
using HotChocolate.Types;

namespace NucleusModels.GraphQl.Inputs.SubInputs;

public sealed class CreateParameterSubInput
{
    [Required]
    public string Name { get; set; }
    
    [Required] 
    public IList<CreateParameterValueSubInput> Values { get; set; }
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

        descriptor
            .Field(nti => nti.Values)
            .Name("values")
            .Type<ListType<CreateParameterValueSubInputType>>();
    }
}