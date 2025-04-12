using FastFoodAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using FastFoodAPI.Services;
using FastFoodAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

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
           Encoding.UTF8.GetBytes(secretKey))
   };
});builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.ApplyMigrations();
app.MapControllers();

await FastFoodDbContext.SeedUsersAsync(app.Services);

app.Run();
