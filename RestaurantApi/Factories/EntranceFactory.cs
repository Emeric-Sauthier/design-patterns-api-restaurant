using RestaurantApi.Models;

namespace RestaurantApi.Factories
{
    public class EntranceFactory : MenuItemFactory
    {
        public override MenuItem CreateMenuItem(string name, decimal price, string category, int preparationTimeMinutes)
        {
            return new MenuItem
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Price = price,
                Category = category,
                PreparationTimeMinutes = preparationTimeMinutes
            };  
        }
    }
}
