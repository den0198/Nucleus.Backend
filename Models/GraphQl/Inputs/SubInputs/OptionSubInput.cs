using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Common.GraphQl;
using HotChocolate.Types;

namespace Models.GraphQl.Inputs.SubInputs;

public class OptionSubInput
{
    [Required]
    public string Value { get; init; }
    
    [Required]
    public int Count { get; init; }
    
    [Required]
    public decimal PriceIncrease { get; init; }
}

public sealed class OptionSubInputType : CoreType<OptionSubInput>
{
    protected override void Configure(IObjectTypeDescriptor<OptionSubInput> descriptor)
    {
        base.Configure(descriptor);

        descriptor
            .Field(osi => osi.Count)
            .Name("count")
            .Type<IntType>();
        
        descriptor
            .Field(osi => osi.Value)
            .Name("value")
            .Type<StringType>();
        
        descriptor
            .Field(osi => osi.PriceIncrease)
            .Name("priceIncrease")
            .Type<DecimalType>();
    }
}