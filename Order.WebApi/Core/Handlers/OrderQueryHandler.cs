using MediatR;
using OrderService.WebApi.Core.Queries;
using OrderService.WebApi.Core.Repositories;
using OrderService.WebApi.Models;
using OrderService.WebApi.Models.Dto;

namespace OrderService.WebApi.Core.Handlers
{
    public class OrderQueryHandler :
        IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderDto>>,
        IRequestHandler<GetOrderByIdQuery, OrderDto?>
    {
        private readonly IOrdersRepository _repository;

        public OrderQueryHandler(IOrdersRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _repository.GetOrdersAsync();
            return orders.Select(x => x.ToDto());
        }

        public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetOrderAsync(request.OrderId);
            return order?.ToDto();
        }
    }
}
