using Microsoft.EntityFrameworkCore;
using Tickets.Application.Common.Interfaces;
using Tickets.Domain.Entities;

namespace Tickets.Infrastructure.Repository;

public class TicketRepository : ITicketRepository
{
    private readonly ITicketsDbContext _context;

    public TicketRepository(ITicketsDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Ticket ticket, CancellationToken cancellationToken)
    {
        await _context.Tickets.AddAsync(ticket, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
