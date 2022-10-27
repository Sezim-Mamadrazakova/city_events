//using city_events.webAPI.AppConfiguration.ApplicationExtentions;

using city_events.webAPI.AppConfiguration.ServicesExtentions;
using city_events.webAPI.AppConfiguration.ApplicationExtentions;
using Serilog;
var builder = WebApplication.CreateBuilder(args);
builder.AddSerilogConfiguration();


builder.Services.AddVersioningConfiguration();
builder.Services.AddControllers();
builder.Services.AddSwaggerConfiguration();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSerilogConfiguration(); //use serilog

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration(); //use swagger
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
try
{
    Log.Information("Application starting...");

    app.Run();
}
catch (Exception ex)
{
    Log.Error("Application finished with error {error}", ex);
}
finally
{
    Log.Information("Application stopped");
    Log.CloseAndFlush();
}


