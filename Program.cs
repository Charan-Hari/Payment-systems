using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Add Stripe configuration to the services container
var stripeSecretKey = builder.Configuration["Stripe:SecretKey"];
builder.Services.AddSingleton(new StripeClient(stripeSecretKey));

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();

app.MapControllers();

app.Run();
