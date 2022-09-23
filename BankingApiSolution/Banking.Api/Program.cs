using Banking.Api.Adapters;
using Banking.Api.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<AccountManager>();
builder.Services.AddTransient<ISystemTime, SystemTime>();
builder.Services.AddHttpClient<IBonusCalculatorApiAdapter, BonusCalculatorApiAdapter>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("bonus-api"));
});
builder.Services.AddSingleton<MongoAccountsAdapter>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("mongo");
    return new MongoAccountsAdapter(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();// this is when the api is up and running.
