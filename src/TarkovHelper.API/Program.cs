using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TarkovHelper.Infrastructure.DAL;
using TarkovHelper.Infrastructure.Middleware;
using TarkovHelper.Infrastructure.Settings;

var builder = WebApplication.CreateBuilder(args);

// Logs
builder.Host.UseSerilog((_, logger) =>
{
    logger.MinimumLevel.Debug()
        .WriteTo.Console()
        .WriteTo.File("logs/tarkovhelper.txt", rollingInterval: RollingInterval.Day);
});

// Mediatr
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Add services to the container.
builder.Services.AddControllers();

// Settings
var generalSettings = builder.Configuration.GetSection("general");
builder.Services.Configure<GeneralSettings>(generalSettings);

//DB
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlite(
        builder.Configuration.GetConnectionString("ApplicationDBConnectionString")
        )
    );

//Add services
builder.Services
    .AddCustomExceptionHandler();


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

app.UseRouting();

app.UseAuthorization();

app.UseCustomExceptionHandler();

app.MapControllers();

app.Run();