using Microsoft.EntityFrameworkCore;
using WeChooz.TechAssessment.Api.Middlewares;
using WeChooz.TechAssessment.Api.Persistance.DbContexts;
using WeChooz.TechAssessment.Api.Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddDbContext<FormationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("formation")
        ?? throw new InvalidOperationException("Connection string 'formation' not found.");

    options.UseSqlServer(connectionString);
});
var redisConnectionString = builder.Configuration.GetConnectionString("cache") ?? throw new InvalidOperationException("Connection string 'cache' not found.");

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<ISessionRepository, SessionRepository>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
//response pattern