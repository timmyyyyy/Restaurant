using MassTransit;
using MassTransit.Transports;
using MediatR;
using Orders.Application.Dtos;
using Orders.Domain.Aggregates.Order;
using Orders.Domain.Aggregates.Order.Parameters;
using Restaurant.Common.ApplicationBuildingBlocks;
using Restaurant.Common.DomainBuildingBlocks;
using Restaurant.IntegrationMessages;

namespace Orders.Application.Commands
{
    public record CreateOrderDraftCommand : IRequest<CreateOrderDraftCommandResponse>
    {
        public string? EmailAddress { get; init; }

        public string? PhoneNumber { get; init; }

        public Guid RestaurantId { get; init; }

        public Guid? CustomerId { get; init; }

        public AddressDto DeliveryAddress { get; init; }

        public List<Guid> MenuItemsIds { get; init; }

        public bool PaymentOnDelivery { get; init; }

        public static explicit operator OrderCreationParams(CreateOrderDraftCommand command)
            => new OrderCreationParams
            {
                EmailAddress = command.EmailAddress,
                PhoneNumber = command.PhoneNumber,
                RestaurantId = command.RestaurantId,
                MenuItemsIds = command.MenuItemsIds,
                PaymentOnDelivery = command.PaymentOnDelivery,
                CustomerId = command.CustomerId,
                AddressCreationParams = new AddressCreationParams()
                {
                    BuildingNumber = command.DeliveryAddress.BuildingNumber,
                    City = command.DeliveryAddress.City,
                    FlatNumber = command.DeliveryAddress.FlatNumber,
                    PostCode = command.DeliveryAddress.PostCode,
                    Street = command.DeliveryAddress.Street,
                }
            };
    }

    public class CreateOrderDraftCommandResponse
    {
        public CreateOrderDraftCommandResponse(Guid orderId)
        {
            OrderId = orderId;
        }

        public Guid OrderId { get; init; }
    }

    public class CreateOrderDraftCommandHandler : IRequestHandler<CreateOrderDraftCommand, CreateOrderDraftCommandResponse>
    {
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IDomainEventCollector _domainEventCollector;

        public CreateOrderDraftCommandHandler(IMediator mediator, IPublishEndpoint publishEndpoint, IDomainEventCollector domainEventCollector)
        {
            _mediator = mediator;
            _publishEndpoint = publishEndpoint;
            _domainEventCollector = domainEventCollector;
        }

        public async Task<CreateOrderDraftCommandResponse> Handle(CreateOrderDraftCommand request, CancellationToken cancellationToken)
        {
            // TODO get from the httpContext after auth
            var orderResult = Order.CreateOrder((OrderCreationParams)request);

            // TODO check if orderResult failed

            var order = orderResult.Value;
            _domainEventCollector.Add(order.DomainEvents);

            //await _mediator.DispatchDomainEvents(order, cancellationToken);

            var orderDto = (OrderDto)order;
            var orderReceivedIntegrationEvent = new OrderReceivedIntegrationEvent(orderDto);
            await _publishEndpoint.Publish(orderReceivedIntegrationEvent, cancellationToken);

            // TODO
            return new CreateOrderDraftCommandResponse(orderResult.Value.Id);
        }
    }
}
