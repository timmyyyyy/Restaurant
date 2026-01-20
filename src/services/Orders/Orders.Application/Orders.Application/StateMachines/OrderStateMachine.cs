using MassTransit;
using Orders.Application.Dtos;
using Restaurant.IntegrationMessages;

using OrderSagaStateDbEntity = Orders.Infrastructure.Models.OrderSagaStateDbEntity;

namespace Orders.Application.StateMachines;

public class OrderStateMachine : MassTransitStateMachine<OrderSagaStateDbEntity>
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

    public Event<OrderReceivedIntegrationEvent> OrderReceived { get; } = null!;
    public Event<PaymentConfirmedIntegrationEvent> PaymentConfirmed { get; } = null!;
    public Event<PaymentFailedIntegrationEvent> PaymentFailed { get; } = null!;
    public Event<OrderAcceptedIntegrationEvent> OrderAccepted { get; } = null!;
    public Event<OrderCancelledIntegrationEvent> OrderCancelled { get; } = null!;
    public Event<OrderDeclinedIntegrationEvent> OrderDeclined { get; } = null!;
    public Event<OrderDeliveredIntegrationEvent> OrderDelivered { get; } = null!;
    public Event<OrderNotDeliveredIntegrationEvent> OrderNotDelivered { get; } = null!;
    public Event<OrderPickedUpForDeliveryIntegrationEvent> OrderPickedUpForDelivery { get; } = null!;
    public Event<OrderReadyIntegrationEvent> OrderReady { get; } = null!;
    public Event<OrderValidatedSuccessfullyIntegrationEvent> OrderValidatedSuccessfully { get; } = null!;
    public Event<OrderValidationFailedIntegrationEvent> OrderValidationFailed { get; } = null!;
    public Event<PaymentRefundedIntegrationEvent> PaymentRefunded { get; } = null!;

    public State Draft { get; private set; } = null!;
    public State DuringValidation { get; private set; } = null!;
    public State ValidationFailed { get; private set; } = null!;
    public State DuringAcceptance { get; private set; } = null!;
    public State Cancelled { get; private set; } = null!;
    public State Declined { get; private set; } = null!;
    public State DuringPaymentRefund { get; private set; } = null!;
    public State DuringPreparation { get; private set; } = null!;
    public State Ready { get; private set; } = null!;
    public State InDelivery { get; private set; } = null!;
    public State Completed { get; private set; } = null!;
    public State NotDelivered { get; private set; } = null!;

    private EventActivityBinder<OrderSagaStateDbEntity, OrderReceivedIntegrationEvent> PassToValidation(
        EventActivityBinder<OrderSagaStateDbEntity, OrderReceivedIntegrationEvent> binder)
    {
        return binder
            .Publish(ctx => new PassOrderToValidationCommand { Order = (OrderDto)ctx.Saga })
            .TransitionTo(DuringValidation);
    }

    private EventActivityBinder<OrderSagaStateDbEntity, T> ProcessPaymentRefund<T>(
        EventActivityBinder<OrderSagaStateDbEntity, T> binder)
        where T : class, IBaseOrderMessage
    {
        return binder
            .Publish(ctx => new RefundPaymentCommand())
            .TransitionTo(DuringPaymentRefund);
    }
}

public static class OrderStateMachineActivityExtensions
{
    public static EventActivityBinder<OrderSagaStateDbEntity, OrderValidatedSuccessfullyIntegrationEvent> ProcessForAcceptance
        (this EventActivityBinder<OrderSagaStateDbEntity, OrderValidatedSuccessfullyIntegrationEvent> binder)
    {
        return binder.PublishAsync(ctx => ctx.Init<PassOrderToAcceptanceCommand>(new { }));
    }

    public static EventActivityBinder<OrderSagaStateDbEntity, PaymentConfirmedIntegrationEvent> PassToValidation
        (this EventActivityBinder<OrderSagaStateDbEntity, PaymentConfirmedIntegrationEvent> binder)
    {
        return binder.Publish(ctx => new PassOrderToValidationCommand { Order = (OrderDto)ctx.Saga });
    }

    public static EventActivityBinder<OrderSagaStateDbEntity, OrderReadyIntegrationEvent> PassToDelivery
        (this EventActivityBinder<OrderSagaStateDbEntity, OrderReadyIntegrationEvent> binder)
    {
        return binder.PublishAsync(ctx => ctx.Init<PassOrderToDeliveryCommand>(new { }));
    }

    public static EventActivityBinder<OrderSagaStateDbEntity, OrderReceivedIntegrationEvent> InitProcessManager
        (this EventActivityBinder<OrderSagaStateDbEntity, OrderReceivedIntegrationEvent> binder)
    {
        return binder.Then(x =>
        {
            x.Saga.CorrelationId = x.Message.Order.Id;
            x.Saga.PaymentOnDelivery = x.Message.Order.PaymentOnDelivery;
        });
    }
}
