using MatchDataManager.Domain.Common;

namespace MatchDataManager.Domain.Entities;

public class Location : BaseEntity
{
    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;
}