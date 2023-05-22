using FeliveryAPI.Data;
using FeliveryAPI.Models;
using FeliveryAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextFactory<ElDbContext>(
          op =>
          {
              op.UseSqlServer(builder.Configuration.GetConnectionString("MyConn1"));
          }
      );
builder.Services.AddScoped<IRepository<Restaurant>, RestaurantRepoService>();
builder.Services.AddScoped<IRepository<MenuItem>, MenuItemRepoService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
