using MatchDataManager.Application.Common.Exceptions.Shared;
using MatchDataManager.Domain.Common.Constants;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MatchDataManager.Api.Controllers;

public class ErrorController : ControllerBase
{
    [Route("/error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, message, errors) = exception switch
        {
            IServiceValidationException serviceValidationException => (
                (int)serviceValidationException.StatusCode,
                serviceValidationException.ErrorMessage,
                serviceValidationException.Errors),
            IServiceException serviceException => (
                (int)serviceException.StatusCode,
                serviceException.ErrorMessage,
                null),
            _ => (StatusCodes.Status500InternalServerError,
                ErrorMessages.Exception.UnexpectedErrorOccurred,
                null)
        };

        return errors == null
            ? Problem(
                statusCode: statusCode,
                title: message)
            : ValidationProblem(
                modelStateDictionary: CreateModelStateDictionary(errors),
                statusCode: statusCode,
                title: message);
    }

        private static ModelStateDictionary CreateModelStateDictionary(IDictionary<string, string[]> errors)
        {
            ModelStateDictionary modelStateDictionary = new();

            foreach (var errorArray in errors.Values)
            {
                foreach (var error in errorArray)
                {
                    modelStateDictionary.AddModelError(errors.Keys.First(), error);
                }
            }

            return modelStateDictionary;
        }
}
