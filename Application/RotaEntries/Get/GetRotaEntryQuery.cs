using Domain.RotaEntries;
using MediatR;

namespace Application.RotaEntries.Get;

public record GetRotaEntryQuery(Guid Id) :IRequest<RotaEntry>
{ }