using MatchDataManager.Domain.Common.Constants;
using System.Net;

namespace MatchDataManager.Application.Common.Exceptions.Shared;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}
