using RestaurantApi.Models;

namespace RestaurantApi.OrderStates.Implementations
{
    public class OrderInPreparation : OrderState
    {
        public OrderInPreparation(Order order) : base(order)
        {
            Console.WriteLine($"Order {_order.Id} is now in preparation.");
        }

        public override string GetStateName()
        {
            return "InPreparation";
        }

        public override void NextState()
        {
            _order.SetState(new OrderReady(_order));
        }
    }
}
