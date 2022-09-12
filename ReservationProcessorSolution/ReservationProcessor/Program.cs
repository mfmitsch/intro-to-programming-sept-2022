using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder();

builder.Services.AddScoped<CourseRegistrationManager>();

var app = builder.Build();

app.MapPost("/registrations", (
    [FromBody] CourseRegistrationRequest request,
    [FromServices] CourseRegistrationManager manager) =>
{
    var response = manager.RegisterForCourse(request);
    if (response.IsRegistered)
    {
        return Results.Ok(response);
    }
    else
    {
        return Results.BadRequest(response);
    }
});


Console.WriteLine("Fixing to run your web application!");
app.Run();
Console.WriteLine("Done running your web application!");

