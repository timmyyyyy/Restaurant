using MassTransit;
using Restaurant.IntegrationMessages;

namespace Restaurant.Application.Consumers;

public class ValidateOrderConsumer : IConsumer<PassOrderToValidationCommand>
{
    public Task Consume(ConsumeContext<PassOrderToValidationCommand> context)
    {
        return Task.CompletedTask;
    }
}
