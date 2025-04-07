namespace PaymentSystem.Models
{
    public class PaymentRequest
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "USD"; // Default to USD if not provided
    }
}
