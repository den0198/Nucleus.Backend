using AutoFixture;

namespace TestsHelpers;

public static class AnyValue
{
    private static readonly Fixture fixture = new();

    public static string String => fixture.Create<string>();
    public static string ShortString => string.Join("",String.Take(8));
    public static long Long => Math.Max(1, fixture.Create<long>());
    public static int Int => Math.Max(1, fixture.Create<int>());
    public static short Short => Math.Max((short)1, fixture.Create<short>());
    public static string Email => $"{ShortString}@{ShortString}.com";
}