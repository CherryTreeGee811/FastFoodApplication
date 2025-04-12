using FastFoodAPI.Entities;
using FastFoodAPI.Extensions;
using FastFoodAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "FastFoodAPI",
        Version = "v1",
        Description = "API for managing employees and operations in a fast food application.",
        Contact = new OpenApiContact
        {
            Name = "FastFoodAPI Team",
            Email = "support@fastfoodapi.com"
        }
    });
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Add Employee Manager Service
builder.Services.AddScoped<IEmployeeManagerService, EmployeeManagerService>();

builder.Services.AddDbContext<FastFoodDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FastFoodDB"))
    .ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning))
);


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FastFoodAPI v1");
        c.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root
    });
    app.MapOpenApi();
}
app.UseCors();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.ApplyMigrations();
app.UseAuthorization();

app.MapControllers();

app.Run();
