using MassTransit;
using Orders.Application.Commands;
using Orders.Application.Dtos;
using Restaurant.IntegrationMessages;
using Orders.Application.StateMachines.Activities;
using Orders.Domain.Aggregates.Order;
using Orders.Domain.Aggregates.Order.DomainEvents;
using Orders.Infrastructure.Models;

using OrderDbEntity = Orders.Infrastructure.Models.OrderDbEntity;

namespace Orders.Application.StateMachines
{
    public class OrderStateMachine : MassTransitStateMachine<OrderDbEntity>
    {
        public OrderStateMachine()
        {
            InstanceState(x => x.CurrentState);

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

        private EventActivityBinder<OrderDbEntity, OrderReceivedIntegrationEvent> PassToValidation(
            EventActivityBinder<OrderDbEntity, OrderReceivedIntegrationEvent> binder)
        {
            return binder
                .Publish(ctx => new PassOrderToValidationCommand((OrderDto)ctx.Saga))
                .TransitionTo(DuringValidation);
        }

        private EventActivityBinder<OrderDbEntity, T> ProcessPaymentRefund<T>(
            EventActivityBinder<OrderDbEntity, T> binder)
            where T: class, IBaseOrderMessage
        {
            return binder
                .Publish(ctx => new RefundPaymentCommand())
                .TransitionTo(DuringPaymentRefund);
        }
    }

    public static class OrderStateMachineActivityExtensions
    {
        public static EventActivityBinder<OrderDbEntity, OrderValidatedSuccessfullyIntegrationEvent> ProcessForAcceptance
            (this EventActivityBinder<OrderDbEntity, OrderValidatedSuccessfullyIntegrationEvent> binder)
        {
            return binder.PublishAsync(ctx => ctx.Init<PassOrderToAcceptanceCommand>(new { }));
        }

        public static EventActivityBinder<OrderDbEntity, PaymentConfirmedIntegrationEvent> PassToValidation
            (this EventActivityBinder<OrderDbEntity, PaymentConfirmedIntegrationEvent> binder)
        {
            return binder.Publish(ctx => new PassOrderToValidationCommand((OrderDto)ctx.Saga));
        }

        public static EventActivityBinder<OrderDbEntity, OrderReadyIntegrationEvent> PassToDelivery
            (this EventActivityBinder<OrderDbEntity, OrderReadyIntegrationEvent> binder)
        {
            return binder.PublishAsync(ctx => ctx.Init<PassOrderToDeliveryCommand>(new { }));
        }

        public static EventActivityBinder<OrderDbEntity, OrderReceivedIntegrationEvent> InitProcessManager
            (this EventActivityBinder<OrderDbEntity, OrderReceivedIntegrationEvent> binder)
        {
            return binder.Then(x =>
            {
                x.Saga.CorrelationId = x.Message.Order.Id;
                x.Saga.PhoneNumber = x.Message.Order.PhoneNumber;
                x.Saga.EmailAddress = x.Message.Order.EmailAddress;
                x.Saga.RestaurantId = x.Message.Order.RestaurantId;
                x.Saga.CustomerId = x.Message.Order.CustomerId;
                x.Saga.DeliveryAddress = (AddressDbEntity)x.Message.Order.DeliveryAddress;
                x.Saga.MenuItemsIds = x.Message.Order.MenuItemsIds;
            });
        }
    }
}
