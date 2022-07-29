using Common.MapperConfigurations;

namespace BLL.UnitTests;

public abstract class UnitTest
{
    protected UnitTest()
    {
        CoreMapperConfiguration.AddConfigurations();
    }
}