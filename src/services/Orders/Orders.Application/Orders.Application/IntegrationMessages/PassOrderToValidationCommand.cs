using Orders.Application.Dtos;

namespace Orders.Application.IntegrationMessages
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
