namespace Common.MapperConfigurations;

public partial class CoreMapperConfiguration
{
    public static void AddConfiguration()
    {
        registerUser();
        token();
        signIn();
        UsersInfo();
    }
}