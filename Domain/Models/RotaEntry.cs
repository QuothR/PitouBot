namespace Domain.Models;

public class RotaEntry
{
    public Id Id { get; }
    public DateTimeInterval Interval { get; }
    public List<User> Users { get; }
}