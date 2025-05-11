using Microsoft.EntityFrameworkCore;
using Tickets.Application.Common.Interfaces;
using Tickets.Domain.Entities;

namespace Tickets.Infrastructure.Persistence;

public class TicketsDbContext : DbContext, ITicketsDbContext
{
    public TicketsDbContext(DbContextOptions<TicketsDbContext> options) : base(options)
    {
    }

    public DbSet<Ticket> Tickets => Set<Ticket>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Title).IsRequired().HasMaxLength(200);
            entity.Property(t => t.Price).IsRequired();
            entity.Property(t => t.CreatedAt).IsRequired();
        });
    }
}
