using DependencyInjection.Application.Attributes;
using DependencyInjection.Domain.Contracts;

namespace DependencyInjection.Application.Services
{
    public record Product(string Name, decimal Price);

    [Service]
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IPaymentService _paymentService;
        private readonly List<Product> _products = [];

        // DIP: Die Abhaengigkeit soll von aussen kommen
        public ShoppingCartService(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
            Console.WriteLine($"Product {product.Name} added to cart");
        }

        public void PayOrder()
        {
            _paymentService.MakePayment(_products.Select(p => p.Price).Sum());
        }
    }
}
