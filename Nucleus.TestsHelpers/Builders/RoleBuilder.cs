namespace Nucleus.TestsHelpers.Builders;

public class RoleBuilder : CoreBuilder<Nucleus.ModelsLayer.Entities.Role>
{
    public RoleBuilder()
    {
        Entity = new Nucleus.ModelsLayer.Entities.Role
        {
            Id = AnyValue.Long,
            Name = AnyValue.ShortString
        };
    }
}