using MassTransit;
using MediatR;
using Orders.Application.Dtos;
using Orders.Domain.Aggregates.Order;
using Orders.Domain.Aggregates.Order.Parameters;
using Orders.Infrastructure;
using Restaurant.Common.ApplicationBuildingBlocks;
using Restaurant.IntegrationMessages;

namespace Orders.Application.Commands;

public record CreateOrderDraftCommand : IRequest<OperationResult<CreateOrderDraftCommandResponse>>
{
    public string? EmailAddress { get; init; }

    public string? PhoneNumber { get; init; }

    public Guid RestaurantId { get; init; }

    public Guid? CustomerId { get; init; }

    public required AddressDto DeliveryAddress { get; init; }

    public required List<Guid> MenuItemsIds { get; init; }

    public bool PaymentOnDelivery { get; init; }

    public static explicit operator OrderCreationParams(CreateOrderDraftCommand command)
        => new()
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
        : IRequestHandler<CreateOrderDraftCommand, OperationResult<CreateOrderDraftCommandResponse>>
{
    public async Task<OperationResult<CreateOrderDraftCommandResponse>> Handle(CreateOrderDraftCommand request, CancellationToken cancellationToken)
    {
        // TODO get from the httpContext after auth
        var orderResult = Order.CreateOrder((OrderCreationParams)request);

        if (!orderResult.IsSuccess)
        {
            return (OperationResult)orderResult;
        }

        var order = orderResult.Value;
        domainEventCollector.Add(order.DomainEvents);

        var orderDto = (OrderDto)order;
        var orderReceivedIntegrationEvent = new OrderReceivedIntegrationEvent(orderDto);
        await publishEndpoint.Publish(orderReceivedIntegrationEvent, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        return OperationResult<CreateOrderDraftCommandResponse>.Success(new (orderResult.Value.Id));
    }
}
