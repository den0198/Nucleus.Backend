using Nucleus.ModelsLayer.Entities;

namespace Nucleus.TestsHelpers.Builders;

public sealed class RoleBuilder : IBuilder<Role>
{
    public Role Build()
    {
        return new Role
        {
            Id = AnyValue.Long,
            Name = AnyValue.ShortString
        };
    }
}