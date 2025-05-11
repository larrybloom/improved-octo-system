using System;
using MediatR;

namespace Tickets.Application.Commands.CreateTicket;

    public class CreateTicketCommand : IRequest<Guid>
    {
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
