using MassTransit;
using Restaurant.Application;

namespace Restaurant.Application.Consumers
{
    public class ValidateOrderConsumer : IConsumer<ValidateOrderCommand>
    {
        public Task Consume(ConsumeContext<ValidateOrderCommand> context)
        {
            
        }
    }
}
