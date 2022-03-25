namespace TestsHelpers.TestMocks.Role;

public static class RoleTestMock
{
    public static Models.Entities.Role Get(string? name = default) =>
        new()
        {
            Id = AnyValue.Long,
            Name = name ?? AnyValue.ShortString
        };
}