using RestaurantApi.Models;

namespace RestaurantApi.OrderStates.Implementations
{
    public class OrderReceived : OrderState
    {
        public OrderReceived(Order order) : base(order)
        {
            Console.WriteLine($"Order {order.Id} has been received.");
        }

        public override string GetStateName()
        {
            return "Received";
        }

        public override void NextState()
        {
            _order.SetState(new OrderInPreparation(_order));
        }
    }
}
