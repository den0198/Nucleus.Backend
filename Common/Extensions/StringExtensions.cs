namespace Common.Extensions;

public static class StringExtensions
{
    public static string FirstLetterToLower(this string text)
    {
        var charArray = text.ToCharArray();
        charArray[0] = char.ToLower(charArray[0]);

        return string.Join("", charArray);
    }
}