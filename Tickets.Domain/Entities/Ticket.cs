namespace Tickets.Domain.Entities;

public class Ticket{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}