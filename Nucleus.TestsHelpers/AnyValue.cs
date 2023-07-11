using AutoFixture;

namespace Nucleus.TestsHelpers;

public static class AnyValue
{
    private static readonly Fixture fixture = new();
    private static readonly Random random = new();

    public static string String => fixture.Create<string>();
    public static string ShortString => string.Join("",String.Take(8));
    public static long Long => Math.Max(1, fixture.Create<long>());
    public static decimal Decimal => Math.Max(1, fixture.Create<decimal>());
    public static short Short => Math.Max((short)1, fixture.Create<short>());
    public static string Email => $"{ShortString}@{ShortString}.com";
    public static string Password => String + "123!@#";
    public static int Random(int min, int max) => random.Next(min, max);
}