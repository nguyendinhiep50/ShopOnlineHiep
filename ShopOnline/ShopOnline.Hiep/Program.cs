using Serilog;
using ShopOnline.Hiep;
using ShopOnline.Hiep.Application;
using ShopOnline.Hiep.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();

builder.Host.UseSerilog();

//builder.RegisterServices(typeof(Program));

var services = builder.Services;
var configuration = builder.Configuration;

services.AddApplicationServices();
services.AddInfrastructureServices(configuration);
services.AddWebServices();

services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin",
    builder => builder
        .SetIsOriginAllowed((origin) => true)
        .AllowAnyHeader()
        .AllowAnyMethod()
    );
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
