using MatchDataManager.Domain.Common.Constants;
using System.Net;

namespace MatchDataManager.Application.Common.Exceptions.Shared;

public interface IServiceValidationException : IServiceException
{
    public IDictionary<string, string[]> Errors { get; }
}
