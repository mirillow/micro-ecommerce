using CartService.Api.Mapper;
using CartService.Application;
using CartService.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



builder.Services.AddDbContext<CartDbContext>(options =>
    options.UseInMemoryDatabase("CartDb"));

builder.Services.AddAutoMapper(typeof(CartMappingProfile));
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<CartAppService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

// Configure the HTTP request pipeline.

app.MapOpenApi();



app.UseHttpsRedirection();
app.MapControllers();
app.Run();

