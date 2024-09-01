using MassTransit;
using Restaurant.Contracts;

namespace Restaurant.API.Application.Consumers
{
    public class ValidateOrderConsumer : IConsumer<ValidateOrderCommand>
    {
        public Task Consume(ConsumeContext<ValidateOrderCommand> context)
        {
            
        }
    }
}
