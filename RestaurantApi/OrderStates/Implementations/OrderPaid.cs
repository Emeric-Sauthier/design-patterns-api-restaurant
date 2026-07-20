using RestaurantApi.Models;

namespace RestaurantApi.OrderStates.Implementations
{
    public class OrderPaid : OrderState
    {
        public OrderPaid(Order order) : base(order)
        {
            Console.WriteLine($"Order {_order.Id} has been paid.");
        }

        public override OrderStatusEnum GetState()
        {
            return OrderStatusEnum.Paid;
        }

        public override void NextState()
        {
            throw new InvalidOperationException("Cannot change state. It is in 'Paid' state.");
        }
    }
}
