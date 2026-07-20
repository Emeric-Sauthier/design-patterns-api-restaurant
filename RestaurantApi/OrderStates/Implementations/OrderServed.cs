using RestaurantApi.Models;

namespace RestaurantApi.OrderStates.Implementations
{
    public class OrderServed : OrderState
    {
        public OrderServed(Order order) : base(order)
        {
            Console.WriteLine($"Order {_order.Id} served successfully.");
        }

        public override string GetStateName()
        {
            return "Served";
        }

        public override void InPreparation()
        {
            throw new InvalidOperationException("Cannot prepare order. It is in Served state.");
        }

        public override void Paid()
        {
            _order.SetState(new OrderPaid(_order));
        }

        public override void Ready()
        {
            throw new InvalidOperationException("Cannot serve order. It is in Served state.");
        }

        public override void Served()
        {
            throw new InvalidOperationException("Cannot serve order. It is in Served state.");
        }
    }
}
