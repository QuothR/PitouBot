using Domain.RotaEntries;
using MediatR;

namespace Application.RotaEntries.Get;

public sealed class Handler : IRequestHandler<GetRotaEntryQuery, RotaEntry>
{
    private readonly IRotaEntryRepository _repository;

    public Handler(IRotaEntryRepository repository)
    {
        _repository = repository;
    }

    public async Task<RotaEntry> Handle(GetRotaEntryQuery request, CancellationToken cancellationToken)
    {
        var entry = await _repository.Get(request.Id);

        if (entry is null)
            throw new RotaEntryNotFoundException(request.Id);

        return entry;
    }
}