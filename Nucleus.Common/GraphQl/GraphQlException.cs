using Nucleus.ModelsLayer.GraphQl;

namespace Nucleus.Common.GraphQl;

public sealed class GraphQlException : Exception
{
    public GraphQlException(ErrorResponseGraphQl errorResponseGraphQl)
    {
        
        int.TryParse(errorResponseGraphQl.Errors.First().Errors.Code, out var result);
        Code = result;
    }

    public int Code { get; }
}