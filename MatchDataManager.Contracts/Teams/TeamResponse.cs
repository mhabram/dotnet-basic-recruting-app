namespace MatchDataManager.Contracts.Teams;

public record TeamResponse(
    Guid Id,
    string Name,
    string CoachName);
