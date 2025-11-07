using Demo_Web_API.Data;
using Demo_Web_API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDBContext>(
    options => options.UseInMemoryDatabase("UserDB"));

builder.Services.AddScoped<UserService>();

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
