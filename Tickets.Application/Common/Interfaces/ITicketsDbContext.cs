using Microsoft.EntityFrameworkCore;
using Tickets.Domain.Entities;

namespace Tickets.Application.Common.Interfaces;

public interface ITicketsDbContext
{
    DbSet<Ticket> Tickets { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}