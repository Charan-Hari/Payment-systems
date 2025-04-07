using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using Microsoft.Extensions.Configuration;

namespace PaymentSystem.Services
{
    public class PayPalClient
    {
        private readonly PayPalHttpClient _client;

        // Constructor for PayPalClient
        public PayPalClient(IConfiguration configuration)
        {
            var clientId = configuration["PayPal:ClientId"];
            var clientSecret = configuration["PayPal:ClientSecret"];
            _client = new PayPalHttpClient(new SandboxEnvironment(clientId, clientSecret));
        }

        // Method to get PayPal client
        public PayPalHttpClient GetClient()
        {
            return _client;
        }
    }
}
