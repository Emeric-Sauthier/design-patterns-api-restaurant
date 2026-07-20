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

        public override void InPreparation()
        {
            throw new InvalidOperationException("Cannot prepare order. It is in 'Paid' state.");
        }

        public override void Paid()
        {
            throw new InvalidOperationException("Cannot pay order. It is in 'Paid' state.");
        }

        public override void Ready()
        {
            throw new InvalidOperationException("Cannot mark order as ready. It is in 'Paid' state.");
        }

        public override void Served()
        {
            throw new InvalidOperationException("Cannot serve order. It is in 'Paid' state.");
        }
    }
}
