using MatchDataManager.Application.Common.Exceptions.Shared;
using MatchDataManager.Domain.Common.Constants;
using System.Net;

namespace MatchDataManager.Application.Common.Exceptions.Team;

public class TeamNullException : Exception, IServiceException
{
    private readonly string _message = ErrorMessages.Exception.NotFound;
    private readonly HttpStatusCode _statusCode = HttpStatusCode.NotFound;

    public TeamNullException(string? message) : base(message)
    {
        StatusCode = _statusCode;
        ErrorMessage = _message;
    }

    public HttpStatusCode StatusCode { get; }

    public string ErrorMessage { get; }
}
