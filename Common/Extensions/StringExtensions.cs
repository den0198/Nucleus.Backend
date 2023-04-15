namespace Common.Extensions;

public static class StringExtensions
{
    public static string FirstLetterToLower(this string text)
    {
        var charArray = text.ToCharArray();
        charArray[0] = char.ToLower(charArray[0]);

        return string.Join("", charArray);
    }

    public static bool IsEqual(this string value, string other)
    {
        return checkBothIsNull(value, other) || (value != null && string.Equals(value, other, StringComparison.Ordinal));
    }

    public static bool IsNotEqual(this string value, string other)
    {
        return !value.IsEqual(other);
    }

    private static bool checkBothIsNull(string value, string other)
    {
        return value == null && other == null;
    }
}