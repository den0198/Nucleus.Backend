using Nucleus.ModelsLayer.Entities;

namespace Nucleus.TestsHelpers.Builders;

public sealed class StoreBuilder : IBuilder<Store>
{ 
    public Store Build()
    {
        return new Store
        {   
            Id = AnyValue.Long,
            Name = AnyValue.ShortString,
            SellerId = AnyValue.Long
        };
    }
}