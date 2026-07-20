using RestaurantApi.Models;

namespace RestaurantApi.OrderStates.Implementations
{
    public class OrderReady : OrderState
    {
        public OrderReady(Order order) : base(order)
        {
            Console.WriteLine($"Order {_order.Id} is now ready.");
        }

        public override string GetStateName()
        {
            return "Ready";
        }

        public override void NextState()
        {
            _order.SetState(new OrderServed(_order));
        }
    }
}
