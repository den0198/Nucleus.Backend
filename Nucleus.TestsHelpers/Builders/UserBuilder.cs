namespace Nucleus.TestsHelpers.Builders;

public class UserBuilder : CoreBuilder<Nucleus.ModelsLayer.Entities.User>
{
    public UserBuilder()
    {
        Entity = new Nucleus.ModelsLayer.Entities.User
        {
            Id = AnyValue.Long,
            UserName = AnyValue.ShortString,
            Email = AnyValue.Email,
            PhoneNumber = AnyValue.ShortString,
        };
    }
}