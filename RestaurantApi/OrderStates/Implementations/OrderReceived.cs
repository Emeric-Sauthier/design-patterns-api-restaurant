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

        public override void InPreparation()
        {
            _order.SetState(new OrderInPreparation(_order));
        }

        public override void Ready()
        {
            throw new InvalidOperationException("Cannot mark order as ready. It is in 'Received' state.");
        }

        public override void Served()
        {
            throw new InvalidOperationException("Cannot serve order. It is in 'Received' state.");
        }

        public override void Paid()
        {
            throw new InvalidOperationException("Cannot mark order as paid. It is in 'Received' state.");
        }
    }
}
