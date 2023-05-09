using Nucleus.ModelsLayer.Service.Parameters;
using Nucleus.TestsHelpers;

namespace Nucleus.BLL.UnitTests.TestData;

public sealed class ParameterTestData
{
    public ParameterTestData()
    {
        CreateParametersParameters = Builder.CreateParametersParameters.Build();
    }
    
    public CreateParametersParameters CreateParametersParameters { get; }
}