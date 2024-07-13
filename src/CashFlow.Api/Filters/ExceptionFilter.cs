using CashFlow.Communication.Responses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is CashFlowApiException)
        {
            HandleProjectException(context);
        }
        else
        {
            HandleUnknownError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        var cashFlowApiException = (CashFlowApiException)context.Exception;
        var errorResponse = new ResponseErrorJson(cashFlowApiException.GetErrors());

        context.HttpContext.Response.StatusCode = cashFlowApiException.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }

    private void HandleUnknownError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOWN_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
        
    }
