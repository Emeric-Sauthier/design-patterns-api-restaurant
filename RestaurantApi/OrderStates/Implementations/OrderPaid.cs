using RestaurantApi.Models;

namespace RestaurantApi.OrderStates.Implementations
{
    public class OrderPaid : OrderState
    {
        public OrderPaid(Order order) : base(order)
        {
            Console.WriteLine($"Order {_order.Id} has been paid.");
        }

        public override string GetStateName()
        {
            return "Paid";
        }

        public override void NextState()
        {
            throw new InvalidOperationException("Cannot change state. It is in 'Paid' state.");
        }
    }
}
