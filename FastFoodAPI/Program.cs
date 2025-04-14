using FastFoodAPI.Entities;
using FastFoodAPI.Extensions;
using FastFoodAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

using FastFoodAPI.Services;
using FastFoodAPI.Extensions;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

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

builder.Services.AddOpenApi();

// Add Employee Manager Service
builder.Services.AddScoped<IEmployeeManagerService, EmployeeManagerService>();

// Register the Training service
builder.Services.AddScoped<ITrainingService, TrainingService>();

// Register the Shift Management service
builder.Services.AddScoped<IShiftManagementService, ShiftManagementService>();

builder.Services.AddDbContext<FastFoodDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FastFoodDB"))
    .ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning))
);

// CORS
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy => {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<IdentityOptions> (options => {
    options.User.RequireUniqueEmail = true;
});

builder.Services.AddIdentity<Employee, IdentityRole>()
    .AddEntityFrameworkStores<FastFoodDbContext>()
    .AddDefaultTokenProviders();

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];
if (string.IsNullOrEmpty(secretKey)) {
    throw new InvalidOperationException("JWT SecretKey is not configured.");
}

builder.Services.AddAuthentication(options => {
   options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
   options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => {
   options.TokenValidationParameters = new TokenValidationParameters
   {
       ValidateIssuer = true,
       ValidateAudience = true,
       ValidateLifetime = true,
       ValidateIssuerSigningKey = true,
       ValidIssuer = jwtSettings["validIssuer"],
       ValidAudience = jwtSettings["validAudience"],
       IssuerSigningKey = new SymmetricSecurityKey(
           Encoding.UTF8.GetBytes(secretKey)),
       RoleClaimType = ClaimTypes.Role // Ensure roles are properly mapped
   };
   
   // Check token against the blacklist
   options.Events = new JwtBearerEvents
   {
       OnTokenValidated = context =>
       {
           var token = context.SecurityToken as JwtSecurityToken;
           var tokenString = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
           
           if (AuthService.IsTokenInvalidated(tokenString))
           {
               context.Fail("This token has been revoked");
           }
           
           return Task.CompletedTask;
       }
   };
});

builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
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

app.UseAuthentication();
app.UseAuthorization();

app.ApplyMigrations();
app.MapControllers();

await FastFoodDbContext.SeedRolesAsync(app.Services);
await FastFoodDbContext.SeedUsersAsync(app.Services);

app.Run();