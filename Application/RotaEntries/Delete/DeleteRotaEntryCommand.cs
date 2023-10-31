using MediatR;

namespace Application.RotaEntries.Delete;

public record DeleteRotaEntryCommand(Guid Id) : IRequest;