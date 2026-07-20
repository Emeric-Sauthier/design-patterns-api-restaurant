using RestaurantApi.Models;

namespace RestaurantApi.Factories
{
    public abstract class MenuItemFactory
    {
        public abstract MenuItem CreateMenuItem(string name, decimal price, int preparationTimeMinutes);
    }
}
