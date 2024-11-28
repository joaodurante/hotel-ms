using Application.DTOs;

namespace Application.Responses.Payment
{
    public class PaymentResponse : Response
    {
        public PaymentStateDTO Data { get; set; }
    }
}
