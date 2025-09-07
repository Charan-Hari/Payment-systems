using PaymentSystem.Models;
using System.Threading.Tasks;

namespace PaymentSystem.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentResponse> CreatePaymentAsync(PaymentRequest paymentRequest);
        Task<PaymentResponse?> CapturePaymentAsync(string orderId);
    }
}
