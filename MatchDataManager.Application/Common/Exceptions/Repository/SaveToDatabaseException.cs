using MatchDataManager.Application.Common.Exceptions.Shared;
using MatchDataManager.Domain.Common.Constants;
using System.Net;

namespace MatchDataManager.Application.Common.Exceptions.Repository;

public class SaveToDatabaseException : Exception, IServiceException
{
    private readonly string _message = ErrorMessages.Exception.DatabaseSaveError;
    private readonly HttpStatusCode _statusCode = HttpStatusCode.BadRequest;
    public SaveToDatabaseException()
    {
        ErrorMessage = _message;
        StatusCode = _statusCode;
    }

    public SaveToDatabaseException(string? message, Exception? innerException) : base(message, innerException)
    {
        StatusCode = _statusCode;
        ErrorMessage = _message;
    }

    public HttpStatusCode StatusCode { get; }

    public string ErrorMessage { get; }
}
