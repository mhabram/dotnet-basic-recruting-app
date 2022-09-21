using MatchDataManager.Domain.Common;

namespace MatchDataManager.Domain.Entities;

public class Team : BaseEntity
{
    public string Name { get; set; } = null!;

    public string CoachName { get; set; } = null!;
}