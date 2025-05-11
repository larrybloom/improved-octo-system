using MediatR;
using Tickets.Domain.Entities;
using Tickets.Application.Common.Interfaces;

namespace Tickets.Application.Commands.CreateTicket;

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, Guid>
{
    private readonly ITicketRepository _ticketRepository;

    public CreateTicketCommandHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<Guid> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = new Ticket
        {
            Title = request.Title,
            Price = request.Price
        };

        await _ticketRepository.AddAsync(ticket, cancellationToken);
        return ticket.Id;
    }
}