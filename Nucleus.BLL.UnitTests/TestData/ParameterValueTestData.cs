using Nucleus.ModelsLayer.Service.Parameters;
using Nucleus.TestsHelpers;

namespace Nucleus.BLL.UnitTests.TestData;

internal sealed class ParameterValueTestData
{
    public ParameterValueTestData()
    {
        CreateParameterValuesParameters = Builder.RegisterUserParameters.Build();
    }
    
    public CreateParameterValuesParameters CreateParameterValuesParameters { get; }
}