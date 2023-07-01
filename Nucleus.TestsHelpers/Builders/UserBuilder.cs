using Nucleus.ModelsLayer.Entities;

namespace Nucleus.TestsHelpers.Builders;

public sealed class UserBuilder : IBuilder<User>
{
    public User Build()
    {
        return new User
        {
            Id = AnyValue.Long,
            UserName = AnyValue.ShortString,
            Email = AnyValue.Email,
            PhoneNumber = AnyValue.ShortString,
        };
    }
}