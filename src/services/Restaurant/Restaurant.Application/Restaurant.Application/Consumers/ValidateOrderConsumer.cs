using MassTransit;
using Restaurant.Application;
using Restaurant.Application.IntegrationMessages;

namespace Restaurant.Application.Consumers
{
    public class ValidateOrderConsumer : IConsumer<PassOrderToValidationCommand>
    {
        public Task Consume(ConsumeContext<PassOrderToValidationCommand> context)
        {
            return Task.CompletedTask;
        }
    }
}
