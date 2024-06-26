using Microsoft.EntityFrameworkCore;
using StoreWarehouse.API.Configuration;
using StoreWarehouse.Application.Services;
using StoreWarehouse.Domain.Interfaces;
using StoreWarehouse.Infra.Data;
using StoreWarehouse.Infra.Data.Repositories;
using StoreWarehouse.Worker.Producer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDependencyInjectionConfiguration();


builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddTransient<IProductTrackRepository, ProductTrackRepository>();

var app = builder.Build();


//using (var serviceScope = app.Services.CreateScope())
//{
//    var serviceDb = serviceScope.ServiceProvider.GetService<DataContext>();
//    serviceDb.Database.Migrate();
//}

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
