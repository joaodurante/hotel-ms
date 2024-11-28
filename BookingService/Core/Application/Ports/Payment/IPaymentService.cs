using Application.Responses.Payment;

namespace Application.Ports.Payment
{
    public interface IPaymentService
    {
        public Task<PaymentResponse> PayWithCreditCard(string paymentIntention);
        public Task<PaymentResponse> PayWithDebitCard(string paymentIntention);
        public Task<PaymentResponse> PayWithPix(string paymentIntention);
    }
}
