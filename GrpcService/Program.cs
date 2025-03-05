using GrpcService.Services;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Service;

using System.Reflection;
using GrpcService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.ConfigRiraService(builder.Configuration);
builder.Services.AddAutoMapper(typeof(AutomapperProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGrpcService<PersonService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataAccess.Context.RiraContext>();
    context.Database.Migrate();
}

    app.Run();
