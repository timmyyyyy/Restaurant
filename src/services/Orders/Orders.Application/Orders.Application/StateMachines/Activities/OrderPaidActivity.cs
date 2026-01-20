using MassTransit;
using Orders.Application.Dtos;
using Orders.Infrastructure;
using Orders.Infrastructure.Models;
using Restaurant.IntegrationMessages;

namespace Orders.Application.StateMachines.Activities;

public class OrderPaidActivity() : IStateMachineActivity<OrderSagaStateDbEntity, PaymentConfirmedIntegrationEvent>
{
    public async Task Execute(BehaviorContext<OrderSagaStateDbEntity, PaymentConfirmedIntegrationEvent> context,
        IBehavior<OrderSagaStateDbEntity, PaymentConfirmedIntegrationEvent> next)
    {
        // TODO get order details based on order id from payment service
        // then publish validation command

        var order = new OrderDto
        {
            DeliveryAddress = new AddressDto
            {
                PostCode = "",
                City = "",
                Street = "",
                BuildingNumber = ""
            },
            MenuItemsIds = []
        };
        await context.Publish(new PassOrderToValidationCommand { Order = order }, context.CancellationToken);

        await next.Execute(context);
    }

    public void Accept(StateMachineVisitor visitor) => visitor.Visit(this);

    public Task Faulted<TException>(BehaviorExceptionContext<OrderSagaStateDbEntity, PaymentConfirmedIntegrationEvent, TException> context, IBehavior<OrderSagaStateDbEntity, PaymentConfirmedIntegrationEvent> next) where TException : Exception
        => next.Faulted(context);

    public void Probe(ProbeContext context) { }
}
