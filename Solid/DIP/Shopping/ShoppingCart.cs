using Solid.DIP.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.DIP.Shopping
{
    public record Product();

    public class ShoppingCart
    {

        // Wir sollten hier nicht gegen die konkrete Implementierung implementieren
        public PaymentService _paymentService_Bad = new PaymentService();

        private readonly IPaymentService _paymentService;

        // DIP: Die Abhaengigkeit soll von aussen kommen
        public ShoppingCart(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public void AddProduct(Product product)
        {
            // ...
        }

        public void PayOrder()
        {
            _paymentService.MakePayment();
        }
    }
}
