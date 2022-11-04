using Bookings.Payments;
using Bookings.Payments.Application;
using Bookings.Payments.Domain;
using Bookings.Payments.Infrastructure;
using Eventuous;
using Eventuous.AspNetCore;
using Eventuous.Diagnostics.Logging;
using Serilog;

Environment.SetEnvironmentVariable("DAPR_GRPC_PORT", "60052");
Environment.SetEnvironmentVariable("DAPR_HTTP_PORT", "3552");
Environment.SetEnvironmentVariable("ASPNETCORE_URLS", "http://localhost:5052");

TypeMap.RegisterKnownEventTypes();
Logging.ConfigureLog();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDaprClient();

// OpenTelemetry instrumentation must be added before adding Eventuous services
builder.Services.AddOpenTelemetry();

builder.Services.AddServices(builder.Configuration);
builder.Host.UseSerilog();

var app = builder.Build();
app.AddEventuousLogs();

app.UseCloudEvents();
app.UseRouting();

app.UseOpenTelemetryPrometheusScrapingEndpoint();

app.MapPost("/record1",
    (PaymentCommands.RecordPayment cmd, PaymentCommandService service) =>
    {
        Console.WriteLine("handle recoird1");
        service.Handle(cmd, CancellationToken.None);
    }).WithTopic("pubsub1","recordfromdapper");

app.MapGet("/payments/{paymentId}",
    async (string paymentId, IAggregateStore store, CancellationToken cancellationToken) =>
    {
        var item = await store.Load<Payment>(StreamName.For<Payment>(paymentId), cancellationToken);
        return item;
    });

app.MapGet("/test", () => new Test1P("test"));
app.MapPost("/test1", (Test1P c) => c);

app.UseEndpoints(endpoints => endpoints.MapSubscribeHandler());

app.UseSwagger();

// Here we discover commands by their annotations
// app.MapDiscoveredCommands();
app.MapDiscoveredCommands<Payment>();

app.UseSwaggerUI();


var factory = app.Services.GetRequiredService<ILoggerFactory>();
var listener = new LoggingEventListener(factory, "OpenTelemetry");

try
{
    // app.Run("http://localhost:5051");
    app.Run();
    return 0;
}
catch (Exception e)
{
    Log.Fatal(e, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.CloseAndFlush();
    listener.Dispose();
}

record Test1P(string Text);