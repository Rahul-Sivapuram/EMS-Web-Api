using EMS.BAL;
using EMS.DAL;
using EMS.DB.Models;
using EMS.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using EMS.API.Helpers;
using Serilog;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
        });
});
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
ServiceRegistration.RegisterServices(builder.Services);
RepositoryRegistration.RegisterRepositories(builder.Services);
DbContextRegistration.RegisterDbContext(builder.Services, builder.Configuration);

JwtConfiguration.ConfigureJwtAuthentication(builder.Services, builder.Configuration);
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.ClearProviders();
    loggingBuilder.AddSerilog();
});

builder.Host.UseSerilog();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
