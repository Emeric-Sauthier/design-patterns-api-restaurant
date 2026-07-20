using RestaurantApi.Models;
using RestaurantApi.Models.MenuItems;

namespace RestaurantApi.Factories
{
    public class MainDishFactory : MenuItemFactory
    {
        private readonly bool _isVegetarian;

        public MainDishFactory(bool isVegetarian)
        {
            _isVegetarian = isVegetarian;
        }

        public override MainDish CreateMenuItem(string name, decimal price, int preparationTimeMinutes)
        {
            return new MainDish
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Price = price,
                Category = "Main Dish",
                PreparationTimeMinutes = preparationTimeMinutes,
                IsVegetarian = _isVegetarian
            };
        }
    }
}
