using Nucleus.BLL.Exceptions;

namespace Nucleus.API.Filters;

public class GraphQlExceptionFilter : IErrorFilter
{
    private readonly ILogger<GraphQlExceptionFilter> logger;
    public GraphQlExceptionFilter(ILogger<GraphQlExceptionFilter> logger)
    {
        this.logger = logger;
    }
    
    public IError OnError(IError error)
    {
        var code = error.Exception is CoreException t
            ? t.Code.ToString()
            : "500";
        logger.LogError($"Error with code: '{code}' " +
                        $"and exception message: {error.Exception?.Message}," +
                        $"and error message: {error.Message}");
        
        return error.WithCode(code);
    }
}