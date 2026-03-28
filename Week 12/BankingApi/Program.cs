using AutoMapper;
using BankingApi.Data;
using BankingApi.Models;
using BankingApi.Profiles;
using BankingApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add Controllers
builder.Services.AddControllers();


// ✅ Swagger with JWT Support
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    // JWT Security Definition
    options.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Enter: Bearer {your JWT token}"
        });

    // JWT Requirement
    options.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference =
                        new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                },
                new string[] {}
            }
        });
});


// Database
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("BankDb"));


// AutoMapper
builder.Services.AddAutoMapper(typeof(AccountProfile));


// Services
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<PasswordService>();


// JWT Authentication
var key = builder.Configuration["Jwt:Key"];

builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer =
                    builder.Configuration["Jwt:Issuer"],

                ValidAudience =
                    builder.Configuration["Jwt:Audience"],

                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(key))
            };
    });

builder.Services.AddAuthorization();

var app = builder.Build();


// ✅ Always enable Swagger (not only Development)
app.UseSwagger();
app.UseSwaggerUI();


// Seed Data (Optional Test Account)
using (var scope = app.Services.CreateScope())
{
    var db =
        scope.ServiceProvider
        .GetRequiredService<AppDbContext>();

    if (!db.Accounts.Any())
    {
        db.Accounts.Add(new Account
        {
            AccountHolderName = "Rahul Sharma",
            AccountNumber = "123456789012",
            Balance = 50000
        });

        db.SaveChanges();
    }
}


// Middleware Order IMPORTANT
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();