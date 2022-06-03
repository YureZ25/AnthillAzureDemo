using Azure.Storage.Queues;
using StockPriceAPI.Helpers;
using StockPriceAPI.Services;
using StockPriceAPI.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IStockPriceService, StockPriceService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Create queue if not exist
var queueClient = new QueueClient(builder.Configuration[QueueConstaints.QueueConnectionString], builder.Configuration[QueueConstaints.QueueName]);
queueClient.CreateIfNotExists();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
