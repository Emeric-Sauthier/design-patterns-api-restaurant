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

        public override void InPreparation()
        {
            throw new InvalidOperationException("Cannot prepare order. It is in 'Ready' state.");
        }

        public override void Paid()
        {
            throw new InvalidOperationException("Cannot pay order. It is in 'Ready' state.");
        }

        public override void Ready()
        {
            throw new InvalidOperationException("Cannot mark order as ready. It is in 'Ready' state.");
        }

        public override void Served()
        {
            _order.SetState(new OrderServed(_order));
        }
    }
}
