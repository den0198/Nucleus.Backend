namespace Nucleus.TestsHelpers.Builders;

public sealed class RoleBuilder : CoreBuilder<ModelsLayer.Entities.Role>
{
    public RoleBuilder()
    {
        Entity = new ModelsLayer.Entities.Role
        {
            Id = AnyValue.Long,
            Name = AnyValue.ShortString
        };
    }
}