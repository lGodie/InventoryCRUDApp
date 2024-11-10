using InventoryCRUDApp.Application.Interfaces.Repository;
using InventoryCRUDApp.Application.Interfaces.Services;
using InventoryCRUDApp.Application.Services;
using InventoryCRUDApp.Infrastructure.Persistence.Context;
using InventoryCRUDApp.Infrastructure.Repositories.Implementations;
using InventoryCRUDApp.src.Automapper;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer("name=LocalConnection"));
var uriBack = "https://localhost:7110/";

builder
    .Services
    .AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddEndpointsApiExplorer();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(uriBack) });
// Inyección de dependencias
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IProductsUseCase, ProductsUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseRouting();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.UseAuthorization();

app.MapRazorPages();

app.Run();
