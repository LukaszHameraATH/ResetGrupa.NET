using GrupaDotNet.CQRS.Lib.Commands;
using GrupaDotNet.CQRS.Lib.Queries;
using GrupaDotNet.CQRS.Meteorology;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<WeatherForecastRepository>();
//builder.Services.AddTransient<ICommandHandler<AddWeatherForecast>, AddWeatherForecastHandler>();
//builder.Services.AddTransient<IQueryHandler<GetAllWeatherForecast, IEnumerable<WeatherForecast>>, GetAllWeatherForecastHandler>();

builder.Services.RegisterCommandHandlers().RegisterQueryHandlers();
builder.Services.AddTransient<ICommandDispatcher, CommandDispatcher>();
builder.Services.AddTransient<IQueryDispatcher, QueryDispatcher>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

public static class RegisterExtensions
{
    public static IServiceCollection RegisterCommandHandlers(this IServiceCollection services)
    {
        return services.Scan(scan => scan
            // We start out with all types in the assembly of ITransientService
            .FromAssemblyOf<Program>()
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime()
        );
    }

    public static IServiceCollection RegisterQueryHandlers(this IServiceCollection services)
    {
        return services.Scan(scan => scan
            .FromAssemblyOf<Program>()
            .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime()
        );
    }
}
