using MatchDataManager.Domain.Common;

namespace MatchDataManager.Domain.Entities;

public class Team : BaseEntity
{
    public string Name { get; set; } = null!;
    public string CoachName { get; set; } = null!;

    public Team() { }

    public Team(string name, string coachName)
    {
        Id = Guid.NewGuid();
        Name = name;
        CoachName = coachName;
    }

    public Team(Guid id, string name, string coachName)
    {
        Id = id;
        Name = name;
        CoachName = coachName;
    }
}