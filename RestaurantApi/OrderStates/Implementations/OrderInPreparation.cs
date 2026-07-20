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

        public override void InPreparation()
        {
            throw new InvalidOperationException("Cannot prepare order. It is in 'InPreparation' state.");)
        }

        public override void Paid()
        {
            throw new InvalidOperationException("Cannot pay order. It is in 'InPreparation' state.");)
        }

        public override void Ready()
        {
            _order.SetState(new OrderReady(_order));
        }

        public override void Served()
        {
            throw new InvalidOperationException("Cannot serve order. It is in 'InPreparation' state.");)
        }
    }
}
