namespace PaymentSystem.Models
{
    public class PaymentResponse
    {
        public required string OrderId { get; set; }  // Mark as required
        public required string Status { get; set; }   // Mark as required
        public required string Intent { get; set; }   // Mark as required
    }
}
