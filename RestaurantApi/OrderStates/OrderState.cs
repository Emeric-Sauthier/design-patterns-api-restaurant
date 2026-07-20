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

        public abstract void InPreparation();
        public abstract void Ready();
        public abstract void Served();
        public abstract void Paid();

        public abstract string GetStateName();
    }
}
