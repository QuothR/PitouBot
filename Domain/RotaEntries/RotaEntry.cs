namespace Domain.RotaEntries;

public class RotaEntry
{
    public Guid Id { get; }
    public DateTimeInterval Interval { get; }
    public List<User> Users { get; }

    public RotaEntry(DateTimeInterval interval, List<User> users)
    {
        Id = new Guid();
        Interval = interval;
        Users = users;
    }
}