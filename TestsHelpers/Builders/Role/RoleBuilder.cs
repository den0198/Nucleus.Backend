namespace TestsHelpers.Builders.Role;

public class RoleBuilder : CoreBuilder<Models.Entities.Role>
{
    public RoleBuilder()
    {
        Entity = new Models.Entities.Role
        {
            Id = AnyValue.Long,
            Name = AnyValue.ShortString
        };
    }
}