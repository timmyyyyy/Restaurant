using System.Runtime.CompilerServices;
using MassTransit;
using Restaurant.IntegrationMessages;

namespace Orders.Application.StateMachines;

public static class CorrelationInitializer
{
#pragma warning disable CA2255
    [ModuleInitializer]
#pragma warning restore CA2255
    public static void Initialize()
    {
        MessageCorrelation.UseCorrelationId<OrderAcceptedIntegrationEvent>(x => x.OrderId);
        MessageCorrelation.UseCorrelationId<OrderCancelledIntegrationEvent>(x => x.OrderId);
        MessageCorrelation.UseCorrelationId<OrderDeclinedIntegrationEvent>(x => x.OrderId);
        MessageCorrelation.UseCorrelationId<OrderDeliveredIntegrationEvent>(x => x.OrderId);
        MessageCorrelation.UseCorrelationId<OrderNotDeliveredIntegrationEvent>(x => x.OrderId);
        MessageCorrelation.UseCorrelationId<OrderPickedUpForDeliveryIntegrationEvent>(x => x.OrderId);
        MessageCorrelation.UseCorrelationId<OrderReadyIntegrationEvent>(x => x.OrderId);
        MessageCorrelation.UseCorrelationId<OrderReceivedIntegrationEvent>(x => x.Order.Id);
        MessageCorrelation.UseCorrelationId<OrderValidatedSuccessfullyIntegrationEvent>(x => x.OrderId);
        MessageCorrelation.UseCorrelationId<OrderValidationFailedIntegrationEvent>(x => x.OrderId);
        MessageCorrelation.UseCorrelationId<PassOrderToAcceptanceCommand>(x => x.Order.Id);
        MessageCorrelation.UseCorrelationId<PassOrderToDeliveryCommand>(x => x.Order.Id);
        MessageCorrelation.UseCorrelationId<PassOrderToValidationCommand>(x => x.Order.Id);
        MessageCorrelation.UseCorrelationId<PaymentConfirmedIntegrationEvent>(x => x.OrderId);
        MessageCorrelation.UseCorrelationId<PaymentFailedIntegrationEvent>(x => x.OrderId);
        MessageCorrelation.UseCorrelationId<PaymentRefundedIntegrationEvent>(x => x.OrderId);
        MessageCorrelation.UseCorrelationId<RefundPaymentCommand>(x => x.OrderId);
    }
}
