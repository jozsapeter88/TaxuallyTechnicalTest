using Taxually.TechnicalTest;
using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Strategies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

builder.Services.AddSingleton<TaxuallyHttpClient>();
builder.Services.AddSingleton<TaxuallyQueueClient>();
builder.Services.AddSingleton<IVatRegistrationStrategy, UKVatRegistrationStrategy>(provider => new UKVatRegistrationStrategy(provider.GetRequiredService<TaxuallyHttpClient>()));
builder.Services.AddSingleton<IVatRegistrationStrategy, FranceVatRegistrationStrategy>(provider => new FranceVatRegistrationStrategy(provider.GetRequiredService<TaxuallyQueueClient>()));
builder.Services.AddSingleton<IVatRegistrationStrategy, GermanyVatRegistrationStrategy>(provider => new GermanyVatRegistrationStrategy(provider.GetRequiredService<TaxuallyQueueClient>()));
builder.Services.AddControllers();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();