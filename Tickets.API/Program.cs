using Tickets.Application.Common.Interfaces;
using Tickets.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using MediatR;
using Tickets.Application.Commands.CreateTicket;
using FluentValidation.AspNetCore;
using Tickets.Infrastructure.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TicketsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateTicketCommand).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(CreateTicketCommand).Assembly);

builder.Services.AddControllers();

builder.Services.AddControllers().AddFluentValidation();





builder.Services.AddScoped<ITicketsDbContext>(provider => provider.GetRequiredService<TicketsDbContext>());


builder.Services.AddScoped<ITicketRepository, TicketRepository>();



var app = builder.Build();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.Run();

