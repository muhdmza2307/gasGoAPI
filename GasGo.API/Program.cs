using System.Security.Claims;
using Carter;
using GasGo.Data;
using GasGo.Repositories.Repositories.Interfaces;
using GasGo.Repositories.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using GasGo.Common.Options;
using Boxed.AspNetCore;
using static GasGo.Handlers.Users.GetUserById;
using GasGo.Handlers.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Load configuration based on environment
builder.Configuration
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

var authOption = configuration.GetSection("Authentication").Get<AuthenticationOption>();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = authOption!.Authority;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = authOption.ValidateIssuer, // or true, depending on your setup
            ValidIssuers = authOption.ValidIssuers,
            ValidateAudience = authOption.ValidateAudience,
            ValidAudiences = authOption.ValidAudiences,
            ValidateLifetime = authOption.ValidateLifetime,
            ValidateIssuerSigningKey = authOption.ValidateIssuerSigningKey
        };

        options.MetadataAddress = authOption.MetadataAddress;
    });

builder.Services.AddAuthorization();
builder.Services.AddCarter();



builder.Services.ConfigureAndValidateSingleton<SqlServerOption>(configuration.GetSection("SqlServer"));

builder.Services.AddScoped<IQueryHandler<GetUserByIdQuery, GetUserByIdResponse?>, GetUserByIdHandler>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddTransient<IEntityStateManager, EntityStateManager>();
builder.Services.AddScoped<IDataContext, DataContext>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

/*app.MapGet("/", () => "Hello World!")
     .RequireAuthorization();

app.MapGet("/userinfo", (HttpContext httpContext) =>
{
    var user = httpContext.User;

    if (!user.Identity?.IsAuthenticated ?? true)
        return Results.Unauthorized();

    // Try to get the `sub` claim (typically the userId in FusionAuth)
    var userId = user.FindFirst("sub")?.Value
                 ?? user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

    return Results.Ok(new { UserId = userId });
}).RequireAuthorization();*/

app.MapCarter();
app.UseHttpsRedirection();

app.Run();
