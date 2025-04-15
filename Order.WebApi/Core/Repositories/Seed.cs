using OrderService.WebApi.Models.Domain;

namespace OrderService.WebApi.Core.Repositories;

public class Seed
{
    public static IEnumerable<Order> SeedOrders()
    {
        yield return new Order
        {
            CustomerId = "ACME-0815",
            OrderId = "1",
            ProductId = "Staubsauger#45",
            DeliveryDate = DateTime.Now
        };
    }
}