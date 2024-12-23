using WebApiTesting.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using WebApiTesting.DataAccess.Repositories.Abstracts;
using WebApiTesting.DataAccess.Repositories.Concretes;
using WebApiTesting.Business.Services.Abstracts;
using WebApiTesting.Business.Services.Concretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
var connection = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<WebApiTestingDbContext>(options =>
{
    options.UseSqlServer(connection);
});


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
