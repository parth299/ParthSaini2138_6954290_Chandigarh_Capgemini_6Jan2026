using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text;
using log4net;
using log4net.Config;
using System.Reflection;

using OrderApi.Data;
using OrderApi.Repositories;
using OrderApi.Services;
using OrderApi.Mapping;
using OrderApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger + JWT Support

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description =
                "Enter Bearer token"
        });

    options.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference =
                        new OpenApiReference
                        {
                            Type =
                                ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                },
                new string[] {}
            }
        });
});


// JWT Configuration

var key =
    "ThisIsASecretKeyForJwtTokenDontShare";

builder.Services
.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;

    options.DefaultChallengeScheme =
        JwtBearerDefaults.AuthenticationScheme;
})

.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;

    options.SaveToken = true;

    options.TokenValidationParameters =
        new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            IssuerSigningKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(key))
        };
});

builder.Services.AddAuthorization();


// SQL Server

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(
builder.Configuration.GetConnectionString(
"DefaultConnection")));


// Repository Injection

builder.Services.AddScoped<
    IOrderRepository,
    OrderRepository>();


// Service Injection

builder.Services.AddScoped<
    IOrderService,
    OrderService>();


// AutoMapper

builder.Services.AddAutoMapper(
typeof(OrderMappingProfile));


// Build App

var app = builder.Build();


// Load Log4Net

var repository =
    LogManager.GetRepository(
        Assembly.GetEntryAssembly());

XmlConfigurator.Configure(
repository,
new FileInfo(
Path.Combine(
AppContext.BaseDirectory,
"log4net.config")));


// Global Exception Middleware

app.UseMiddleware<ExceptionMiddleware>();


// Swagger

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// JWT

app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();