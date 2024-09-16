//using MassTransit;
//using Payments.API.Application.IntegrationEvents;

//namespace Payments.API.Application.Consumers
//{
//    public class IssueWithOrderConsumer : IConsumer<OrderValidationFailedIntegrationEvent>, IConsumer<OrderDeclinedIntegrationEvent>
//    {
//        public async Task Consume(ConsumeContext<OrderValidationFailedIntegrationEvent> context)
//        {
//            await RefundPayment();
//        }

//        public async Task Consume(ConsumeContext<OrderDeclinedIntegrationEvent> context)
//        {
//            await RefundPayment();
//        }

//        private async Task RefundPayment()
//        {
//            // TODO
//        }
//    }
//}
