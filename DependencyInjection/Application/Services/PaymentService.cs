using DependencyInjection.Application.Attributes;
using DependencyInjection.Domain.Contracts;

namespace DependencyInjection.Application.Services
{
    [Service]
    public class PaymentService : IPaymentService
    {
        private readonly AppSettings _settings;

        public PaymentService(AppSettings settings)
        {
            _settings = settings;
        }

        public void MakePayment(decimal amount)
        {
            Console.WriteLine($"Payed {amount} made with default payment method {_settings.DefaultPaymentMethod}");
        }
    }
}
