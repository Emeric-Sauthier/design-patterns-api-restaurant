using RestaurantApi.Models;

namespace RestaurantApi.Observers.OrderObservers
{
    public class WaiterService : IRestaurantObserver<Order>
    {
        public void Update(Order data)
        {
            if (data.Status != "Ready")
            {
                return;
            }

            Console.WriteLine($"[WaiterService] Received notification for order : {data.Id}");
        }
    }
}
