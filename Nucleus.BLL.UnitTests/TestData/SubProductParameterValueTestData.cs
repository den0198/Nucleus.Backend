using Nucleus.ModelsLayer.Service.Parameters;
using Nucleus.TestsHelpers;

namespace Nucleus.BLL.UnitTests.TestData;

public sealed class SubProductParameterValueTestData
{
    public SubProductParameterValueTestData()
    {
        CreateSubProductParameterValuesParameters = Builder.CreateSubProductParameterValuesParameters.Build();
    }

    public CreateSubProductParameterValuesParameters CreateSubProductParameterValuesParameters { get; }
}