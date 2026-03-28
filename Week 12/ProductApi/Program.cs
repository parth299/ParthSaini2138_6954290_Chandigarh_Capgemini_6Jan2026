var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Add Health Checks
builder.Services.AddHealthChecks();

var app = builder.Build();

// Swagger (for testing API)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// ✅ Map Health Check endpoint
app.MapHealthChecks("/health");

app.Run();