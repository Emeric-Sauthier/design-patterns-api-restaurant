using RestaurantApi.Models;

namespace RestaurantApi.Observers.OrderObservers
{
    public class PaymentService : IRestaurantObserver<Order>
    {
        public void Update(Order data)
        {
            if (data.Status!= OrderStatusEnum.Received && data.Status != OrderStatusEnum.Paid)
            {
                return;
            }
            Console.WriteLine($"[PaymentService] Received notification for order : {data.Id}");
        }
    }
}
