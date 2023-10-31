using Domain.RotaEntries;
using MediatR;

namespace Application.RotaEntries.Create;

public record CreateRotaEntryCommand(
    DateTimeInterval DateTimeInterval, 
    List<User> Users) : IRequest;