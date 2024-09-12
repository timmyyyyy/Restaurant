using MassTransit;
using Orders.Application.Commands;
using Orders.Application.IntegrationMessages;
using Orders.Application.StateMachines.Activities;
using Orders.Domain.Aggregates.Order;
using Orders.Domain.Aggregates.Order.DomainEvents;
using Orders.Infrastructure.Models;

using Order = Orders.Infrastructure.Models.Order;

namespace Orders.Domain.StateMachines
{
    public class OrderStateMachine : MassTransitStateMachine<Order>
    {
        public OrderStateMachine()
        {
            InstanceState(x => x.CurrentState);

            Event(() => OrderReceived, x => x.CorrelateById(context => context.Message.Order.Id));
            Event(() => OrderValidatedSuccessfully, x => x.CorrelateById(context => context.Message.OrderId));

            Initially(
                When(OrderReceived)
                    .InitProcessManager()
                    .IfElse(x => x.Message.Order.PaymentOnDelivery,
                        PassToValidation,
                        x => x.TransitionTo(Draft)
                    )
                );

            During(Draft,
                When(PaymentConfirmed)
                    .PassToValidation()
                    .TransitionTo(DuringValidation),
                When(PaymentFailed)
                    .TransitionTo(Cancelled),
                When(OrderCancelled)
                    .IfElse(x => !x.Saga.PaymentOnDelivery,
                        ProcessPaymentRefund,
                        x => x.TransitionTo(Cancelled)
                    )
                );

            During(DuringValidation,
                When(OrderValidationFailed)
                    .TransitionTo(ValidationFailed),
                When(OrderValidatedSuccessfully)
                    .ProcessForAcceptance()
                    .TransitionTo(DuringAcceptance),
                When(OrderCancelled)
                    .IfElse(x => !x.Saga.PaymentOnDelivery,
                        ProcessPaymentRefund,
                        x => x.TransitionTo(Cancelled)
                    )
                );

            During(DuringAcceptance,
                When(OrderDeclined)
                    .IfElse(x => !x.Saga.PaymentOnDelivery,
                        ProcessPaymentRefund,
                        x => x.TransitionTo(Declined)
                    ),
                When(OrderAccepted)
                    .TransitionTo(DuringPreparation),
                When(OrderCancelled)
                    .IfElse(x => !x.Saga.PaymentOnDelivery,
                        ProcessPaymentRefund,
                        x => x.TransitionTo(Cancelled)
                    )
                );

            During(DuringPaymentRefund,
                When(PaymentRefunded)
                    .TransitionTo(Declined)
                );

            During(DuringPreparation,
                When(OrderReady)
                    .PassToDelivery()
                    .TransitionTo(Ready)
                );

            During(Ready,
                When(OrderPickedUpForDelivery)
                    .TransitionTo(InDelivery)
                );

            During(InDelivery,
                When(OrderDelivered)
                    .TransitionTo(Completed),
                When(OrderNotDelivered)
                    .TransitionTo(NotDelivered)
                );
        }

        public Event<OrderReceivedIntegrationEvent> OrderReceived { get; }
        public Event<PaymentConfirmedIntegrationEvent> PaymentConfirmed { get; }
        public Event<PaymentFailedIntegrationEvent> PaymentFailed { get; }
        public Event<OrderAcceptedIntegrationEvent> OrderAccepted { get; }
        public Event<OrderCancelledIntegrationEvent> OrderCancelled { get; }
        public Event<OrderDeclinedIntegrationEvent> OrderDeclined { get; }
        public Event<OrderDeliveredIntegrationEvent> OrderDelivered { get; }
        public Event<OrderNotDeliveredIntegrationEvent> OrderNotDelivered { get; }
        public Event<OrderPickedUpForDeliveryIntegrationEvent> OrderPickedUpForDelivery { get; }
        public Event<OrderReadyIntegrationEvent> OrderReady { get; }
        public Event<OrderValidatedSuccessfullyIntegrationEvent> OrderValidatedSuccessfully { get; }
        public Event<OrderValidationFailedIntegrationEvent> OrderValidationFailed { get; }
        public Event<PaymentRefundedIntegrationEvent> PaymentRefunded { get; }

        public State Draft { get; private set; }
        public State DuringValidation { get; private set; }
        public State ValidationFailed { get; private set; }
        public State DuringAcceptance { get; private set; }
        public State Cancelled { get; private set; }
        public State Declined { get; private set; }
        public State DuringPaymentRefund { get; private set; }
        public State DuringPreparation { get; private set; }
        public State Ready { get; private set; }
        public State InDelivery { get; private set; }
        public State Completed { get; private set; }
        public State NotDelivered { get; private set; }

        private EventActivityBinder<Order, OrderReceivedIntegrationEvent> PassToValidation(
            EventActivityBinder<Order, OrderReceivedIntegrationEvent> binder)
        {
            binder.PublishAsync(ctx => ctx.Init<PassOrderToValidationCommand>(new { ctx.Message.Order }));
            return binder.TransitionTo(DuringValidation);
        }

        private EventActivityBinder<Order, T> ProcessPaymentRefund<T>(
            EventActivityBinder<Order, T> binder)
            where T: class, IBaseOrderMessage
        {
            binder.PublishAsync(ctx => ctx.Init<RefundPaymentCommand>(new { }));
            return binder.TransitionTo(DuringPaymentRefund);
        }
    }

    public static class OrderStateMachineActivityExtensions
    {
        public static EventActivityBinder<Order, OrderValidatedSuccessfullyIntegrationEvent> ProcessForAcceptance
            (this EventActivityBinder<Order, OrderValidatedSuccessfullyIntegrationEvent> binder)
        {
            return binder.PublishAsync(ctx => ctx.Init<PassOrderToAcceptanceCommand>(new { }));
        }

        public static EventActivityBinder<Order, PaymentConfirmedIntegrationEvent> PassToValidation
            (this EventActivityBinder<Order, PaymentConfirmedIntegrationEvent> binder)
        {
            return binder.Activity(x => x.OfType<OrderPaidActivity>());
        }

        public static EventActivityBinder<Order, OrderReadyIntegrationEvent> PassToDelivery
            (this EventActivityBinder<Order, OrderReadyIntegrationEvent> binder)
        {
            return binder.PublishAsync(ctx => ctx.Init<PassOrderToDeliveryCommand>(new { }));
        }

        public static EventActivityBinder<Order, OrderReceivedIntegrationEvent> InitProcessManager
            (this EventActivityBinder<Order, OrderReceivedIntegrationEvent> binder)
        {
            return binder.Then(x =>
            {
                x.Saga.CorrelationId = x.Message.Order.Id;
                x.Saga.PaymentOnDelivery = x.Message.Order.PaymentOnDelivery;
            });
        }
    }
}
