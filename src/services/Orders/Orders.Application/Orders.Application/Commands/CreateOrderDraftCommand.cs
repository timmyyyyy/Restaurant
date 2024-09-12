﻿using MassTransit;
using MediatR;
using Orders.Application.Dtos;
using Orders.Domain.Aggregates.Order;
using Restaurant.Common.DomainBuildingBlocks;

namespace Orders.Application.Commands
{
    public class CreateOrderDraftCommand : IRequest<OrderDto>
    {
        public string? EmailAddress { get; init; }

        public string? PhoneNumber { get; init; }

        public Guid RestaurantId { get; init; }

        public AddressDto DeliveryAddress { get; init; }

        public List<Guid> MenuItemsIds { get; init; }

        public bool PaymentOnDelivery { get; set; }
    }

    public class CreateOrderDraftCommandHandler : IRequestHandler<CreateOrderDraftCommand, OrderDto>
    {
        private readonly IMediator _mediator;

        public CreateOrderDraftCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OrderDto> Handle(CreateOrderDraftCommand request, CancellationToken cancellationToken)
        {
            var addressResult = Address.CreateAddress(request.DeliveryAddress.PostCode, request.DeliveryAddress.City, request.DeliveryAddress.Street,
                request.DeliveryAddress.BuildingNumber, request.DeliveryAddress.FlatNumber);

            // TODO check if addressResult failed

            // TODO get from the httpContext after auth
            var customerId = Guid.NewGuid();
            var orderResult = Order.CreateOrder(request.EmailAddress, request.PhoneNumber, customerId, request.RestaurantId, 
                addressResult.Value, request.MenuItemsIds, request.PaymentOnDelivery);

            // TODO check if orderResult failed

            var order = orderResult.Value;
            
            await _mediator.DispatchDomainEvents(order, cancellationToken);

            // TODO
            return new OrderDto();
        }
    }
}
