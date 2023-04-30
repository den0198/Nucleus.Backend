namespace Nucleus.TestsHelpers.Builders;

public class RoleBuilder : CoreBuilder<Nucleus.Models.Entities.Role>
{
    public RoleBuilder()
    {
        Entity = new Nucleus.Models.Entities.Role
        {
            Id = AnyValue.Long,
            Name = AnyValue.ShortString
        };
    }
}