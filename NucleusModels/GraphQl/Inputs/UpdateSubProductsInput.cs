using HotChocolate.Types;
using NucleusModels.GraphQl.Inputs.SubInputs;

namespace NucleusModels.GraphQl.Inputs;

public sealed class UpdateSubProductsInput
{
    public IList<UpdateSubProductSubInput> SubProducts { get; init; }
}

public sealed class UpdateSubProductsInputType : CoreType<UpdateSubProductsInput>
{
    protected override void Configure(IObjectTypeDescriptor<UpdateSubProductsInput> descriptor)
    {
        base.Configure(descriptor);
        
        descriptor
            .Field(sii => sii.SubProducts)
            .Name("subProducts")
            .Type<ListType<UpdateSubProductSubInputType>>();
    }
}