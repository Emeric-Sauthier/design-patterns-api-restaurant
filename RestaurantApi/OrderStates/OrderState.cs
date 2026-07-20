using RestaurantApi.Models;

namespace RestaurantApi.OrderStates
{
    public abstract class OrderState
    {
        protected Order _order;

        public OrderState(Order order)
        {
            _order = order;
        }

        public abstract void NextState();

        public abstract OrderStatusEnum GetState();
    }
}
