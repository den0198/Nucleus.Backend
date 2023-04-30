using System.ComponentModel.DataAnnotations;
using HotChocolate.Types;

namespace Nucleus.Models.GraphQl.Inputs;

public sealed class CreateCategoryInput
{
    [Required]
    public string Name { get; set; }
}

public sealed class CreateCategoryInputType : CoreType<CreateCategoryInput>
{
    protected override void Configure(IObjectTypeDescriptor<CreateCategoryInput> descriptor)
    {
        base.Configure(descriptor);
        
        descriptor
            .Field(nti => nti.Name)
            .Name("name")
            .Type<StringType>();
    }
}