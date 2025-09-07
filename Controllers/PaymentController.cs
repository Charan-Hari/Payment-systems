using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Models;  // This includes the PaymentRequest and PaymentResponse models
using PaymentSystem.Services; // The service layer for payment processing
using System.Threading.Tasks;
using PaymentSystem.Services.Interfaces;


namespace PaymentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        // Inject PaymentService into the controller
        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // POST method to create a payment
        [HttpPost("create-payment")]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentRequest paymentRequest)
        {
            if (paymentRequest == null)
            {
                return BadRequest("Payment request cannot be null.");
            }

            // Call the PaymentService to create a payment
            var paymentResponse = await _paymentService.CreatePaymentAsync(paymentRequest.Amount, paymentRequest.Currency);

            if (paymentResponse != null)
            {
                // Return a success response with payment details
                return Ok(new
                {
                    paymentResponse.OrderId,
                    paymentResponse.Status,
                    paymentResponse.Intent
                });
            }
            else
            {
                // Return an error response if payment creation failed
                return StatusCode(500, "Payment creation failed. Please try again.");
            }
        }

        // [HttpPost("capture-payment")]
        // public async Task<IActionResult> CapturePayment([FromBody] CaptureRequest request)
        // {
        //     var paymentResponse = await _paymentService.CapturePaymentAsync(request.OrderId);

        //     if (paymentResponse != null)
        //     {
        //         return Ok(paymentResponse);
        //     }

        //     return BadRequest("Payment capture failed.");
        // }

    }


}
