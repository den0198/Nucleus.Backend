using Nucleus.ModelsLayer.Service.Parameters;
using Nucleus.TestsHelpers;

namespace Nucleus.BLL.UnitTests.TestData;

public sealed class AddOnServiceTestData
{
    public AddOnServiceTestData()
    {
        CreateAddOnsParameters = Builder.CreateAddOnsParameters.Build();
    }

    public CreateAddOnsParameters CreateAddOnsParameters { get; }
}