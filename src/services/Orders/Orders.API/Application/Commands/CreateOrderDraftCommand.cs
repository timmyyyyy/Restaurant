using MassTransit;
using MediatR;
using Orders.API.Application.Dtos;
using Orders.Domain.Aggregates.Order;
using Restaurant.Common.DomainBuildingBlocks;

namespace Orders.API.Application.Commands
{
    public class CreateOrderDraftCommand : IRequest<OrderDto>
    {
        public string? EmailAddress { get; init; }

        public string? PhoneNumber { get; init; }

        public Guid RestaurantId { get; init; }

        public AddressDto DeliveryAddress { get; init; }

        public List<Guid> MenuItemsIds { get; init; }
    }

    public class CreateOrderDraftCommandHandler : IRequestHandler<CreateOrderDraftCommand, OrderDto>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public CreateOrderDraftCommandHandler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task<OrderDto> Handle(CreateOrderDraftCommand request, CancellationToken cancellationToken)
        {
            var addressResult = Address.CreateAddress(request.DeliveryAddress.PostCode, request.DeliveryAddress.City, request.DeliveryAddress.Street,
                request.DeliveryAddress.BuildingNumber, request.DeliveryAddress.FlatNumber);

            // TODO check if addressResult failed

            // TODO get from the httpContext after auth
            var customerId = Guid.NewGuid();
            var orderResult = Order.CreateOrder(request.EmailAddress, request.PhoneNumber, customerId, request.RestaurantId, 
                addressResult.Value, request.MenuItemsIds);

            // TODO check if orderResult failed

            var order = orderResult.Value;
            await _publishEndpoint.DispatchDomainEvents(order);

            // TODO
            return new OrderDto();
        }
    }
}
