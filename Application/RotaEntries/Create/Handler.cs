using Domain.RotaEntries;
using MediatR;

namespace Application.RotaEntries.Create;

public sealed class Handler : IRequestHandler<CreateRotaEntryCommand>
{
    private readonly IRotaEntryRepository _entryRepository;

    public Handler(IRotaEntryRepository entryRepository)
    {
        _entryRepository = entryRepository;
    }

    public async Task Handle(CreateRotaEntryCommand request, CancellationToken cancellationToken)
    {
        var rotaEntry = new RotaEntry(request.DateTimeInterval, request.Users);
        
        _entryRepository.Add(rotaEntry);
    }
}