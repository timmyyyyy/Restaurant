using MassTransit;
using Orders.Application.Commands;
using Orders.Application.IntegrationEvents;
using Orders.Domain.Aggregates.Order.DomainEvents;
using Orders.Infrastructure.Models;

namespace Orders.Domain.StateMachines
{
    public class OrderStateMachine : MassTransitStateMachine<OrderState>
    {
        public OrderStateMachine()
        {
            InstanceState(x => x.CurrentState);


            Event(() => OrderSavedAsDraft, x => x.CorrelateById(context => context.Message.OrderId));
            Event(() => OrderValidatedSuccessfully, x => x.CorrelateById(context => context.Message.OrderId));

            Initially(
                When(OrderDraftCreated)
                    .Publish(context => 
                        new ValidateOrderCommand(context.Message.OrderId, context.Message.RestaurantId, context.Message.MenuItemsIds))
                    .TransitionTo(Draft)
                );

            During(Draft,
                When(OrderValidatedSuccessfully)
                    .TransitionTo(Validated)
                    .Publish(context => new OrderSavedAsDraftIntegrationEvent(context.Message.OrderId)
                    )
                );
        }

        public Event<OrderSavedAsDraftIntegrationEvent> OrderSavedAsDraft { get; }
        //public Event<OrderSubmittedIntegrationEvent> OrderSubmitted { get; }
        //public Event<OrderAcceptedIntegrationEvent> OrderAccepted { get; }
        //public Event<OrderCancelledIntegrationEvent> OrderCancelled { get; }
        //public Event<OrderDeclinedIntegrationEvent> OrderDeclined { get; }
        //public Event<OrderDeliveredIntegrationEvent> OrderDelivered { get; }
        //public Event<OrderNotDeliveredIntegrationEvent> OrderNotDelivered { get; }
        //public Event<OrderPaidIntegrationEvent> OrderPaid { get; }
        //public Event<OrderPickedUpForDeliveryIntegrationEvent> OrderPickedUpForDelivery { get; }
        //public Event<OrderPickUpDeclinedIntegrationEvent> OrderPickUpDeclined { get; }
        //public Event<OrderReadyIntegrationEvent> OrderReady { get; }
        public Event<OrderValidatedSuccessfullyIntegrationEvent> OrderValidatedSuccessfully { get; }
        //public Event<OrderValidationFailedIntegrationEvent> OrderValidationFailed { get; }
        //public Event<PaymentRefundedIntegrationEvent> PaymentRefunded { get; }

        //public Request<OrderState, ValidateOrderRequest, ValidateOrderResponse> ValidateOrder { get; }

        public State Draft { get; private set; }
        public State Validated { get; private set; }
        public State Submitted { get; private set; }
        public State Cancelled { get; private set; }
        public State Accepted { get; private set; }
        public State Declined { get; private set; }
        public State Ready { get; private set; }
        public State Completed { get; private set; }
    }
}
