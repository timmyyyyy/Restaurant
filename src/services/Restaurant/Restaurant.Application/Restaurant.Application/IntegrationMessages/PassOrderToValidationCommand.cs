using Restaurant.Application.Dtos;

namespace Restaurant.IntegrationMessages
{
    public record PassOrderToValidationCommand
    {
        public PassOrderToValidationCommand(OrderDto order)
        {
            Order = order;
        }

        public OrderDto Order { get; private set; }
    }
}
