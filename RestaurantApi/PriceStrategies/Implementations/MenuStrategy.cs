using RestaurantApi.Models;
using System.Linq;

namespace RestaurantApi.PriceStrategies.Implementations
{
    public class MenuStrategy : IPriceStrategy
    {
        private readonly decimal _menuPrice;
        private readonly List<MenuItem> _menuItems;
        private readonly int _menuNumber;

        public MenuStrategy(decimal menuPrice, List<MenuItem> menuItems)
        {
            _menuPrice = menuPrice;
            _menuItems = menuItems;
            _menuNumber = GetMenuNumber();
        }

        public decimal CalculatePrice(decimal basePrice)
        {
            if (!IsApplicable(basePrice))
            {
                return basePrice;
            }

            decimal entranceMenuPrice = _menuItems.OrderBy(item => item.Price).Where(item => item.Category == "Entrance").Take(_menuNumber).Sum(item => item.Price);
            decimal mainDishMenuPrice = _menuItems.OrderBy(item => item.Price).Where(item => item.Category == "Main Dish").Take(_menuNumber).Sum(item => item.Price);
            decimal dessertMenuPrice = _menuItems.OrderBy(item => item.Price).Where(item => item.Category == "Dessert").Take(_menuNumber).Sum(item => item.Price);
            decimal totalMenuPrice = entranceMenuPrice + mainDishMenuPrice + dessertMenuPrice;

            return basePrice - totalMenuPrice + (_menuPrice * _menuNumber);
        }

        public bool IsApplicable(decimal basePrice)
        {
            return _menuNumber > 0;
        }

        public string GetStrategyName()
        {
            return "Menu";
        }

        private int GetMenuNumber()
        {
            int entranceNumber = _menuItems.Count(item => item.Category == "Entrance");
            int mainDishNumber = _menuItems.Count(item => item.Category == "Main Dish");
            int dessertNumber = _menuItems.Count(item => item.Category == "Dessert");

            return int.Min(int.Min(entranceNumber, mainDishNumber), dessertNumber);
        }
    }
}
