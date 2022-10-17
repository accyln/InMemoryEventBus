using InMemoryEventBus.NServiceBus;
using NServiceBus;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseNServiceBus(context =>
{
    var endpointConfiguration = new EndpointConfiguration("Samples.ASPNETCore.Sender");
    var transport = endpointConfiguration.UseTransport<LearningTransport>();
    transport.Routing().RouteToEndpoint(
        assembly: typeof(Message).Assembly,
        destination: "Samples.ASPNETCore.Endpoint");


    return endpointConfiguration;
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<MessageSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
