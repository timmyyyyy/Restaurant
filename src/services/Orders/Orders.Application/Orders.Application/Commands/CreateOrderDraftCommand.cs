using MassTransit;
using MassTransit.Transports;
using MediatR;
using Orders.Application.Dtos;
using Orders.Domain.Aggregates.Order;
using Orders.Domain.Aggregates.Order.Parameters;
using Orders.Infrastructure;
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

    public class CreateOrderDraftCommandResponse(Guid orderId)
    {
        public Guid OrderId { get; init; } = orderId;
    }

    public class CreateOrderDraftCommandHandler(IPublishEndpoint publishEndpoint,
        IDomainEventCollector domainEventCollector, OrdersDbContext dbContext) 
        : IRequestHandler<CreateOrderDraftCommand, CreateOrderDraftCommandResponse>
    {
        public async Task<CreateOrderDraftCommandResponse> Handle(CreateOrderDraftCommand request, CancellationToken cancellationToken)
        {
            // TODO get from the httpContext after auth
            var orderResult = Order.CreateOrder((OrderCreationParams)request);

            // TODO check if orderResult failed

            var order = orderResult.Value;
            domainEventCollector.Add(order.DomainEvents);

            var orderDto = (OrderDto)order;
            var orderReceivedIntegrationEvent = new OrderReceivedIntegrationEvent(orderDto);
            await publishEndpoint.Publish(orderReceivedIntegrationEvent, cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);

            // TODO
            return new CreateOrderDraftCommandResponse(orderResult.Value.Id);
        }
    }
}
