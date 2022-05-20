using Models.GraphQl;

namespace Common.Exception;

public sealed class GraphQlException : System.Exception
{
    public GraphQlException(ErrorResponseGraphQl errorResponseGraphQl)
    {
        Error = errorResponseGraphQl.Errors.First().Error;
    }

    public ErrorResponseGraphQl.GraphQlError.Extensions Error { get; set; }
}