namespace Common.MapperConfigurations;

public static partial class CoreMapperConfiguration
{
    public static void AddConfigurations()
    {
        AddUserConfigurations();
        AddTokenConfigurations();
        AddSignInConfigurations();
    }
}