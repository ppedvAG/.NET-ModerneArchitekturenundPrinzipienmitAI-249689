using OrderService.WebApi.Models.Domain;

namespace OrderService.WebApi.Core.Repositories
{
    public interface IOrdersRepository
    {
        Task CancelOrderAsync(string orderId);
        Task<Order?> GetOrderAsync(string orderId);
        Task<List<Order>> GetOrdersAsync();
        Task<string> PlaceOrderAsync(string customerId, string productId);
    }
}