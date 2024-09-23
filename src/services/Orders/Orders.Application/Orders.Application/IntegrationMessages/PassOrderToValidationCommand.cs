using Orders.Application.Dtos;

namespace Restaurant.IntegrationMessages
{
    public record PassOrderToValidationCommand
    {
        public PassOrderToValidationCommand() { }

        public PassOrderToValidationCommand(OrderDto order)
        {
            Order = order;
        }

        public OrderDto Order { get; private set; }
    }
}
