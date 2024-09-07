using MassTransit;
using Microsoft.EntityFrameworkCore;
using Producer.Data;
using Producer.RabbitMQ;
using Producer.RabbitMQ.Connection;
using Producer.Service;

var builder = WebApplication.CreateBuilder(args);

// Register the DbContext with an in-memory database
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseInMemoryDatabase("ASPNETCoreRabbitMQ"));

// Register RabbitMqConnection as Scoped or Transient
builder.Services.AddScoped<IRabbitMqConnection, RabbitMqConnection>();

// Register services and implementations
builder.Services.AddScoped<IMessageProducer, RabbitMqProducer>(); // Ensure the interface and implementation match
builder.Services.AddScoped<IUserServiceMassTransit, UserService>();
builder.Services.AddScoped<IUserServiceRabbitMqClient, UserService>();

// Configure MassTransit with RabbitMQ
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.ConfigureEndpoints(context);
    });
});

// Add controllers and configure Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
