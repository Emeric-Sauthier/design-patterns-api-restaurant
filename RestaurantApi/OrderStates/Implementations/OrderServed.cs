using RestaurantApi.Models;

namespace RestaurantApi.OrderStates.Implementations
{
    public class OrderServed : OrderState
    {
        public OrderServed(Order order) : base(order)
        {
            Console.WriteLine($"Order {_order.Id} served successfully.");
        }

        public override OrderStatusEnum GetState()
        {
            return OrderStatusEnum.Served;
        }

        public override void NextState()
        {
            _order.SetState(new OrderPaid(_order));
        }
    }
}
