using Microsoft.EntityFrameworkCore;
using shorturl.API.Models;
using shorturl.API.Repositories.Abstract;
using shorturl.API.Repositories.Concrete;
using shorturl.API.Services.Abstract;
using shorturl.API.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ShorturlDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShorturlDb")));

builder.Services.AddScoped<IUrlRepository, UrlRepository>();

builder.Services.AddScoped<IUrlService, UrlService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.RoutePrefix = "";
        options.SwaggerEndpoint("openapi/v1.json", "ShortURL API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
