using FluentValidation;
using Tickets.Application.Commands.CreateTicket;

namespace Tickets.Application.Commands;

public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
{
    public CreateTicketCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Price).GreaterThan(0);
    }

}