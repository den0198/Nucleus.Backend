namespace TestsHelpers.Builders;

public class UserBuilder : CoreBuilder<Models.Entities.User>
{
    public UserBuilder()
    {
        Entity = new Models.Entities.User
        {
            Id = AnyValue.Long,
            UserName = AnyValue.ShortString,
            Email = AnyValue.Email,
            PhoneNumber = AnyValue.ShortString,
        };
    }
}