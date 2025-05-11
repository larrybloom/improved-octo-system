using MediatR;
using Tickets.Domain.Entities;
using Tickets.Application.Common.Interfaces;
using MassTransit;

namespace Tickets.Application.Commands.CreateTicket;

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, Guid>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IPublishEndpoint _publishEndpoint;

    public CreateTicketCommandHandler(ITicketRepository ticketRepository, IPublishEndpoint publishEndpoint)
    {
        _ticketRepository = ticketRepository;
         _publishEndpoint = publishEndpoint;
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