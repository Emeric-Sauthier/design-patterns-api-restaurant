using RestaurantApi.Models;

namespace RestaurantApi.Observers.OrderObservers
{
    public class PayementService : IRestaurantObserver<Order>
    {
        public void Update(Order data)
        {
            if (data.Status != "Received" && data.Status != "Paid")
            {
                return;
            }
            Console.WriteLine($"[PayementService] Received notification for order : {data.Id}");
        }
    }
}
