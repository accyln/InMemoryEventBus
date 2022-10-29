using EventQueueWithMassTransit.Contracts;
using EventQueueWithMassTransit.DataContext;
using EventQueueWithMassTransit.EventBus;
using EventQueueWithMassTransit.Services;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMassTransit(x => {
    x.AddRequestClient<CreatePipeline>();
    x.UsingInMemory((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });

  });
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<SomePublisher>();
builder.Services.AddScoped<SomeConsumer>();
builder.Services.AddScoped<DefaultService>();

//builder.Services.AddHostedService<Worker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
