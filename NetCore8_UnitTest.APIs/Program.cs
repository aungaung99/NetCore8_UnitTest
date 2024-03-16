using Microsoft.EntityFrameworkCore;

using NetCore8_UnitTest.APIs.Data;
using NetCore8_UnitTest.APIs.Interfaces;
using NetCore8_UnitTest.APIs.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NetCoreDemoDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging());

builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

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
