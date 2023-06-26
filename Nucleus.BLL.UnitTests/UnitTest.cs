using Nucleus.Common.MapperConfigurations;

namespace Nucleus.BLL.UnitTests;

public abstract class UnitTest
{
    protected UnitTest()
    {
        MapperConfiguration.AddConfigurations();
    }
}