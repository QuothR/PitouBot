namespace Domain.RotaEntries;

public interface IRotaEntryRepository
{
    Task<RotaEntry> Get(Guid id);
    void Add(RotaEntry rotaEntry);
    void Delete(RotaEntry rotaEntry);
}