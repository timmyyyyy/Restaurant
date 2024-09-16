using MassTransit;
using Orders.Application.Dtos;
using Orders.Application.IntegrationMessages;
using Orders.Infrastructure;
using Orders.Infrastructure.Models;

namespace Orders.Application.StateMachines.Activities
{
    public class OrderPaidActivity : IStateMachineActivity<OrderDbEntity, PaymentConfirmedIntegrationEvent>
    {
        private readonly OrdersDbContext _ordersDbContext;

        public OrderPaidActivity(OrdersDbContext ordersDbContext)
        {
            _ordersDbContext = ordersDbContext;
        }

        public async Task Execute(BehaviorContext<OrderDbEntity, PaymentConfirmedIntegrationEvent> context, IBehavior<OrderDbEntity, PaymentConfirmedIntegrationEvent> next)
        {
            // TODO get order details based on order id from payment service
            // then publish validation command
             
            var order = new OrderDto();
            await context.Publish(new PassOrderToValidationCommand(order), context.CancellationToken);

            await next.Execute(context);
        }

        public void Accept(StateMachineVisitor visitor) => visitor.Visit(this);

        public Task Faulted<TException>(BehaviorExceptionContext<OrderDbEntity, PaymentConfirmedIntegrationEvent, TException> context, IBehavior<OrderDbEntity, PaymentConfirmedIntegrationEvent> next) where TException : Exception
            => next.Faulted(context);

        public void Probe(ProbeContext context) { }
    }
}
