using DependencyInjection.Application.Services;

namespace DependencyInjection.Domain.Contracts
{
    public interface IShoppingCartService
    {
        void AddProduct(Product product);
        void PayOrder();
    }
}