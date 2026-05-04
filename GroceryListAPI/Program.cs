using GroceryListAPI.Data;
using GroceryListAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<GroceryListService>();
// Register the database context with dependency injection.
// This tells the app to use SQLite with the connection string from appsettings.json,
// and allows GroceryDbContext to be automatically provided to controllers/services.
builder.Services.AddDbContext<GroceryDbContext>(options => options.UseSqlite(
    builder.Configuration.GetConnectionString("DefaultConnection")));
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

app.UseAuthorization();

app.MapControllers();

app.Run();
