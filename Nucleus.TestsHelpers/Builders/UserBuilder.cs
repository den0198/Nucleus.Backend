namespace Nucleus.TestsHelpers.Builders;

public class UserBuilder : CoreBuilder<ModelsLayer.Entities.User>
{
    public UserBuilder()
    {
        Entity = new ModelsLayer.Entities.User
        {
            Id = AnyValue.Long,
            UserName = AnyValue.ShortString,
            Email = AnyValue.Email,
            PhoneNumber = AnyValue.ShortString,
        };
    }
}