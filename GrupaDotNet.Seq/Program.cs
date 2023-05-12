using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();

var logger = new LoggerConfiguration()
    .WriteTo.File("Logs.txt")
    .WriteTo.Console()
    .WriteTo.Seq("http://localhost:5341/", apiKey: "L411bIgaghbC4csckUIl")
    .CreateLogger();

builder.Logging.AddSerilog(logger);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Use((context, next) =>
{
    try
    {
        return next(context);
    }
    catch (Exception e)
    {
        logger.Error(e, "B³¹d!");
    }

    return Task.CompletedTask;
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/home", () =>
{
    return "home";
})
.WithOpenApi();

app.MapGet("/error", () =>
{
    throw new Exception("B³¹d aplikacji");
})
.WithOpenApi();

app.MapGet("/logging", ()=>{
        var value = new { test = "test", test2 = 2 };
    logger.Information("Test {@value}", value);
})
.WithOpenApi();

app.Run();