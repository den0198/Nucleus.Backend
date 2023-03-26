namespace TestsHelpers.Builders;

public class UserBuilder : CoreBuilder<NucleusModels.Entities.User>
{
    public UserBuilder()
    {
        Entity = new NucleusModels.Entities.User
        {
            Id = AnyValue.Long,
            UserName = AnyValue.ShortString,
            Email = AnyValue.Email,
            PhoneNumber = AnyValue.ShortString,
        };
    }
}