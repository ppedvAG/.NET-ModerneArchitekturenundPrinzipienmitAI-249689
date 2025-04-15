using OrderService.WebApi.Models.Domain;
using OrderService.WebApi.Models.Dto;

namespace OrderService.WebApi.Models
{
    public static class OrderMappers
    {
        public static OrderDto? ToDto(this Order order)
        {
            return order is null
                ? null
                : new OrderDto
                {
                    OrderId = order.OrderId,
                    CustomerId = order.CustomerId,
                    ProductId = order.ProductId,
                    DeliveryDate = order.DeliveryDate,
                    IsCancelled = order.IsCancelled,
                    IsDelivered = !order.DeliveryDate.Equals(default)
                };
        }
    }
}
