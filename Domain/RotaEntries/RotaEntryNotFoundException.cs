namespace Domain.RotaEntries;

public sealed class RotaEntryNotFoundException : Exception
{
    public RotaEntryNotFoundException(Guid guid) :
        base($"Rota Entry with ID {guid} was not found")
    { }
}