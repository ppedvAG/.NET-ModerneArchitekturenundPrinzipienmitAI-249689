using MediatR;
using OrderService.WebApi.Models.Dto;

namespace OrderService.WebApi.Core.Queries
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<OrderDto>> { }
}
