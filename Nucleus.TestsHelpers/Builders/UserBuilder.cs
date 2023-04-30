namespace Nucleus.TestsHelpers.Builders;

public class UserBuilder : CoreBuilder<Nucleus.Models.Entities.User>
{
    public UserBuilder()
    {
        Entity = new Nucleus.Models.Entities.User
        {
            Id = AnyValue.Long,
            UserName = AnyValue.ShortString,
            Email = AnyValue.Email,
            PhoneNumber = AnyValue.ShortString,
        };
    }
}