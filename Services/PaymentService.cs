using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using PaymentSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentSystem.Services
{
    public class PaymentService
    {
        private readonly PayPalHttpClient _paypalClient; // Updated PayPalHttpClient

        public PaymentService(PayPalHttpClient paypalClient) // Changed from PayPalClient to PayPalHttpClient
        {
            _paypalClient = paypalClient;
        }

        // Method to create a payment with PayPal
        public async Task<PaymentResponse?> CreatePaymentAsync(decimal amount, string currency)
        {
            
            // Create the OrderRequest with necessary details
            var orderRequest = new OrderRequest()
            {
              

                PurchaseUnits = new List<PurchaseUnitRequest>
                {
                    new PurchaseUnitRequest
                    {
                        AmountWithBreakdown = new AmountWithBreakdown
                        {
                            CurrencyCode = "USD",
                            Value = "100" // Convert amount from cents to dollars
                        },
                        Description = "Payment for services"
                    }
                },
                ApplicationContext = new ApplicationContext
                {
                    BrandName = "HariCharan",
                    LandingPage = "BILLING",
                    ShippingPreference = "NO_SHIPPING",
                    UserAction = "PAY_NOW"
                }
            };

            // Create OrdersCreateRequest and set the Intent here
            var ordersCreateRequest = new OrdersCreateRequest();
            ordersCreateRequest.RequestBody(orderRequest);
            ordersCreateRequest.Headers.Add("intent", "CAPTURE"); 


            try
            {
                // Execute the request using the PayPalHttpClient
                var response = await _paypalClient.Execute(ordersCreateRequest); // PayPalHttpClient used here
                var order = response.Result<PayPalCheckoutSdk.Orders.Order>();

                if (order != null)  // Ensure the order is not null
                {
                    return new PaymentResponse
                    {
                        OrderId = order.Id,
                        Status = order.Status,
                        Intent = "CAPTURE" // Return the Intent as part of the response
                    };
                }
            }
            catch (System.Exception ex)
            {
                // Log the exception
                System.Console.WriteLine("Error creating payment: " + ex.Message);
            }

            return null;  // Return null if the payment creation failed or there was an error
        }
    }
}
