using MatchDataManager.Domain.Common.Constants;
using System.Net;

namespace MatchDataManager.Application.Common.Exceptions.Shared;

public class MatchDataManagerValidationException : Exception, IServiceValidationException
{
    public MatchDataManagerValidationException(IDictionary<string, string[]> errors)
    {
        Errors = errors;
        ErrorMessage = ErrorMessages.Exception.InvalidDataProvided;
        StatusCode = HttpStatusCode.BadRequest;
    }

    public IDictionary<string, string[]> Errors { get; }

    public HttpStatusCode StatusCode { get; }

    public string ErrorMessage { get; }
}
 