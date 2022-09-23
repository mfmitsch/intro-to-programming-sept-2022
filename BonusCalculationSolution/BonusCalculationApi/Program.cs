using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ISystemTime, SystemTime>();
builder.Services.AddTransient<IProvideTheBusinessClock, StandardBusinessClock>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/bonus-calculations", ([FromBody] BonusCalculationRequest request, [FromServices] IProvideTheBusinessClock _clock) => {

    // If the balance >= 5000 AND it is during business hours, they get a 5% bonus, otherwise, nothing.
    var bonus = _clock.IsDuringBusinessHours() && request.Balance >= 5000M ? request.AmountOfDeposit * .05M : 0;
    var response = new BonusCalculationResponse { Amount = bonus};
    return Results.Ok(response);
});

app.Run();


public record BonusCalculationRequest
{
    public decimal Balance { get; set; }
    public decimal AmountOfDeposit { get; set; }

    public string AccountNumber { get; set; } = string.Empty;
}

public record BonusCalculationResponse
{
    public decimal Amount { get; set; }
}

public interface ISystemTime 
{
    public DateTime GetCurrent();
}

public class SystemTime : ISystemTime
{
    public DateTime GetCurrent() => DateTime.Now;
   
}

public interface IProvideTheBusinessClock 
{
    bool IsDuringBusinessHours();
}

public class StandardBusinessClock : IProvideTheBusinessClock
{
    private readonly ISystemTime _systemTime;

    public StandardBusinessClock(ISystemTime systemTime)
    {
        _systemTime = systemTime;
    }

    public bool IsDuringBusinessHours()
    {
        return _systemTime.GetCurrent().Hour >= 9 && _systemTime.GetCurrent().Hour < 17;
    }
}
