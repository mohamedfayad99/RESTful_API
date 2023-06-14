using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Rstfulapi.Logging;
using Rstfulapi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger=new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("LogPath/VillaLogg.txt",rollingInterval:RollingInterval.Day).CreateLogger();
builder.Host.UseSerilog();

//connectionstrings
builder.Services.AddDbContext<Applicationdb>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionsql"));
});
// Add services to the container.

builder.Services.AddControllers( options =>
{
    options.ReturnHttpNotAcceptable = true;
}
).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ILogging, Logging>();

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
