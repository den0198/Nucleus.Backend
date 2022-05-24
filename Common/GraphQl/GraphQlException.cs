using Models.GraphQl;

namespace Common.GraphQl;

public sealed class GraphQlException : Exception
{
    public GraphQlException(ErrorResponseGraphQl errorResponseGraphQl)
    {
        Code = int.Parse(errorResponseGraphQl.Errors.First().Errors.Code);
    }

    public int Code { get; }
}