namespace TestsHelpers.Builders;

public class RoleBuilder : CoreBuilder<NucleusModels.Entities.Role>
{
    public RoleBuilder()
    {
        Entity = new NucleusModels.Entities.Role
        {
            Id = AnyValue.Long,
            Name = AnyValue.ShortString
        };
    }
}