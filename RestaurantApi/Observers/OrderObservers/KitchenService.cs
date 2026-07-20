using RestaurantApi.Models;
using RestaurantApi.Observers;

namespace RestaurantApi.Observers.OrderObservers
{
    public class KitchenService : IRestaurantObserver<Order>
    {
        public void Update(Order data)
        {
            if (data.Status != OrderStatusEnum.Received && data.Status != OrderStatusEnum.InPreparation)
            {
                return;
            }
            Console.WriteLine($"[KitchenService] Received notification for order : {data.Id}");
        }
    }
}
