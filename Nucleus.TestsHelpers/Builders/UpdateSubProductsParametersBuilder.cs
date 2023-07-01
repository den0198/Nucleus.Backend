using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.TestsHelpers.Builders;

public sealed class UpdateSubProductsParametersBuilder : IBuilder<UpdateSubProductsParameters>
{
    public UpdateSubProductsParameters Build()
    {
        return new UpdateSubProductsParameters(Builder.SubProductCommonDto.BuildMany());
    }
}