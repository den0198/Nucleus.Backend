namespace Nucleus.Common.Managers;

public static class EnumManager
{
    public static Dictionary<int, string> ToDictionary<TEnum>() where TEnum : Enum 
    {
        var enums = Enum.GetValues(typeof(TEnum));

        return enums.Cast<object?>().ToDictionary(obj => (int)obj!, obj => obj!.ToString()!);
    }
}