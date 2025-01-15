// Sets up the application, initializing, configuration, dependency injection, and other services.
using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi



//[builder.services]: Provides a container to register application services, such as middleware, controllers, or third-party libraries
//[addOpenApi]: Registers OpenAPI/Swagger services for documenting and testing your API. Swagger is a popular tool for
// generating API documentation and testing interfaces.
builder.Services.AddOpenApi();

//Add StoreContext for Database Interactions
builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// Register Controllers to the service - [Only registrations and No Routes]
builder.Services.AddControllers();

//This finalizes the setup and prepares the application for processing HTTP requests.
var app = builder.Build();

// Configure the HTTP request pipeline.
//[Part 1] Checks if the application is running in the development environment
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();// [Part 2] Maps the OpenAPI endpoints (e.g., /swagger), but only in development mode to avoid exposing them in production.
}

//Redirects all HTTP requests to HTTPS for secure communication.
app.UseHttpsRedirection();

// Registering the controller [ROUTES] - without this line the wont be route handling
app.MapControllers();

//An array of strings representing weather summaries.
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

//[app.MapGet]: Defines a GET endpoint at /weatherforecaste
//Generates a forecaste for the next 5 days
app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)), //Calculates dates for the forecast.
            Random.Shared.Next(-20, 55), //Generates a random temperature in Celsius.
            summaries[Random.Shared.Next(summaries.Length)] //Picks a random summary.
        ))
        .ToArray(); // Converts generated data into an array
    return forecast; // And returns it
})
.WithName("GetWeatherForecast");  // Assigns a name to the endpoint for identification in OpenAPI/Swagger

app.Run();  //Starts the web server and listens for incoming requests

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}