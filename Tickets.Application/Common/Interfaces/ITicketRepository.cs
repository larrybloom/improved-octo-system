using Tickets.Domain.Entities;

namespace Tickets.Application.Common.Interfaces;

public interface ITicketRepository
{
    Task AddAsync(Ticket ticket, CancellationToken cancellationToken);
}
