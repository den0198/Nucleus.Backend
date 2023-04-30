﻿using Nucleus.BLL.Exceptions;

namespace Nucleus.API.Filters;

public class GraphQlExceptionFilter : IErrorFilter
{
    public IError OnError(IError error)
    {
        return error.WithCode(error.Exception is CoreException t 
            ? t.Code.ToString() 
            : "500");
    }
}