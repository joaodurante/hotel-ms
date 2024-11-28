using Application.DTOs;
using Application.Paypal.Exceptions;
using Application.Ports.Payment;
using Application.Responses.Payment;

namespace Application.Paypal
{
    public class PaypalAdapter : IPaypalService
    {
        public Task<PaymentResponse> PayWithCreditCard(string paymentIntention)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(paymentIntention))
                {
                    throw new InvalidPaymentIntentionException();
                }

                var res = new PaymentStateDTO
                {
                    CreatedAt = DateTime.Now,
                    Message = "Payment succesfull",
                    PaymentId = "123",
                    Status = Status.Success,
                };

                return Task.FromResult(
                    new PaymentResponse
                    {
                        Data = res,
                    }
                );
            }
            catch (InvalidPaymentIntentionException e)
            {
                var res = new PaymentResponse
                {
                    Success = false,
                    Error = Responses.ErrorCodes.INVALID_PAYMENT_INTENTION
                };

                return Task.FromResult(res);
            }
        }
        public Task<PaymentResponse> PayWithDebitCard(string paymentIntention)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentResponse> PayWithPix(string paymentIntention)
        {
            throw new NotImplementedException();
        }
    }
}
