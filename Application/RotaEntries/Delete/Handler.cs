using Domain.RotaEntries;
using MediatR;

namespace Application.RotaEntries.Delete;

public sealed class Handler : IRequestHandler<DeleteRotaEntryCommand>
{
    private readonly IRotaEntryRepository _repository;

    public Handler(IRotaEntryRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteRotaEntryCommand request, CancellationToken cancellationToken)
    {
        var entry = await _repository.Get(request.Id);

        if (entry is null)
            throw new RotaEntryNotFoundException(request.Id);
        
        _repository.Delete(entry);
    }
}