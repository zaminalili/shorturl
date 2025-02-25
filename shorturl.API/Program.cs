using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using shorturl.API.Models;
using shorturl.API.Repositories.Abstract;
using shorturl.API.Repositories.Concrete;
using shorturl.API.Services.Abstract;
using shorturl.API.Services.Concrete;
using shorturl.API.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ShorturlDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShorturlDb")));

builder.Services.AddScoped<IUrlRepository, UrlRepository>();

builder.Services.AddScoped<IUrlService, UrlService>();

builder.Services.AddScoped<IMigrationRunner, MigrationRunner>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly).AddFluentValidationAutoValidation();

var app = builder.Build();

var scope = app.Services.CreateScope();
var migrationRunner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
await migrationRunner.MigrateAsync();

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
