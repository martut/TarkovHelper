using TarkovHelper.API.Framework;
using TarkovHelper.Infrastructure.Exceptions;
using TarkovHelper.Infrastructure.Extensions;
using TarkovHelper.Infrastructure.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton(builder.Configuration.GetSettings<GeneralSettings>());

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

    var generalSettings = app.Services.GetService<GeneralSettings>();
    Console.WriteLine($"App Name: {generalSettings?.Name}");
}

app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();