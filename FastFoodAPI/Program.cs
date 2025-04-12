using FastFoodAPI.Entities;
using FastFoodAPI.Extensions;
using FastFoodAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
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
    app.MapOpenApi();
}
app.UseCors();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.ApplyMigrations();
app.UseAuthorization();

app.MapControllers();

app.Run();
