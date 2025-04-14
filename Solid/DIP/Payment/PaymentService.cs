using Solid.DIP.Shopping;

namespace Solid.DIP.Payment
{
    public class PaymentService : IPaymentService
    {
        public void MakePayment()
        {
            Console.WriteLine("Payment made");
        }
    }
}
