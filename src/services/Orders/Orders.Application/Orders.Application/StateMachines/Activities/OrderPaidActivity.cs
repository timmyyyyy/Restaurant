using MassTransit;
using Orders.Application.Dtos;
using Orders.Application.IntegrationMessages;
using Orders.Infrastructure;
using Orders.Infrastructure.Models;

namespace Orders.Application.StateMachines.Activities
{
    public class OrderPaidActivity : IStateMachineActivity<Order, PaymentConfirmedIntegrationEvent>
    {
        private readonly OrdersDbContext _ordersDbContext;

        public OrderPaidActivity(OrdersDbContext ordersDbContext)
        {
            _ordersDbContext = ordersDbContext;
        }

        public async Task Execute(BehaviorContext<Order, PaymentConfirmedIntegrationEvent> context, IBehavior<Order, PaymentConfirmedIntegrationEvent> next)
        {
            // TODO get order details based on order id from payment service
            // then publish validation command
             
            var order = new OrderDto();
            await context.Publish(new PassOrderToValidationCommand(order), context.CancellationToken);

            await next.Execute(context);
        }

        public void Accept(StateMachineVisitor visitor) => visitor.Visit(this);

        public Task Faulted<TException>(BehaviorExceptionContext<Order, PaymentConfirmedIntegrationEvent, TException> context, IBehavior<Order, PaymentConfirmedIntegrationEvent> next) where TException : Exception
            => next.Faulted(context);

        public void Probe(ProbeContext context) { }
    }
}
