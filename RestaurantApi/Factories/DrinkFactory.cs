using RestaurantApi.Models;
using RestaurantApi.Models.MenuItems;

namespace RestaurantApi.Factories
{
    public class DrinkFactory : MenuItemFactory
    {
        private readonly bool _isAlcoholic;

        public DrinkFactory(bool isAlcoholic)
        {
            _isAlcoholic = isAlcoholic;
        }

        public override MenuItem CreateMenuItem(string name, decimal price, int preparationTimeMinutes)
        {
            return new Drink
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Price = price,
                Category = "Drink",
                PreparationTimeMinutes = preparationTimeMinutes,
                IsAlcoholic = _isAlcoholic
            };
        }
    }
}
