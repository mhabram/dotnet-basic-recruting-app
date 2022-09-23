using MatchDataManager.Domain.Common;

namespace MatchDataManager.Domain.Entities;

public class Location : BaseEntity
{
    public string Name { get; set; } = null!;
    public string City { get; set; } = null!;

    public Location() { }

    public Location(string name, string city)
    {
        Id = Guid.NewGuid();
        Name = name;
        City = city;
    }

    public Location(Guid id, string name, string city)
    {
        Id = id;
        Name = name;
        City = city;
    }
}