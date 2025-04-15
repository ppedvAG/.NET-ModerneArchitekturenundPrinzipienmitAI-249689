using MediatR;
using OrderService.WebApi.Models.Dto;

namespace OrderService.WebApi.Core.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public GetOrderByIdQuery(string orderId)
        {
            OrderId = orderId;
        }

        public string OrderId { get; }
    }
}
