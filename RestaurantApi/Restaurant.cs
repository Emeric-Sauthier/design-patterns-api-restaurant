using RestaurantApi.Factories;
using RestaurantApi.Models;
using RestaurantApi.Repositories;

namespace RestaurantApi
{
    public class Restaurant
    {
        private readonly OrderRepository _orderRepository;
        private readonly MenuItemRepository _menuItemRepository;

        public Restaurant(OrderRepository orderRepository, MenuItemRepository menuItemRepository)
        {
            _orderRepository = orderRepository;
            _menuItemRepository = menuItemRepository;

            InitializeMenu();
        }

        public List<MenuItem> GetMenu()
        {
            return _menuItemRepository.GetAll();
        }

        public List<Order> GetOrders()
        {
            return _orderRepository.GetAll();
        }

        public Order? GetOrderById(string id)
        {
            return _orderRepository.GetById(id);
        }

        private void InitializeMenu()
        {
            var entranceFactory = new EntranceFactory();
            _menuItemRepository.Add(entranceFactory.CreateMenuItem("Bruschetta", 6.99m, "Entrance", 10));
            _menuItemRepository.Add(entranceFactory.CreateMenuItem("Salad", 5.99m, "Entrance", 4));

            var nonVegetarianMainDishFactory = new MainDishFactory(false);
            _menuItemRepository.Add(nonVegetarianMainDishFactory.CreateMenuItem("Grilled Chicken", 12.99m, "Main Dish", 15));

            var vegetarianMainDishFactory = new MainDishFactory(true);
            _menuItemRepository.Add(vegetarianMainDishFactory.CreateMenuItem("Vegetarian Pasta", 10.99m, "Main Dish", 12));

            var dessertFactory = new DessertFactory();
            _menuItemRepository.Add(dessertFactory.CreateMenuItem("Chocolate Cake", 4.99m, "Dessert", 8));
            _menuItemRepository.Add(dessertFactory.CreateMenuItem("Ice Cream", 3.99m, "Dessert", 5));

            var alcoholicDrinkFactory = new DrinkFactory(true);
            _menuItemRepository.Add(alcoholicDrinkFactory.CreateMenuItem("Beer", 5.99m, "Drink", 2));
            _menuItemRepository.Add(alcoholicDrinkFactory.CreateMenuItem("Wine", 7.99m, "Drink", 3));

            var nonAlcoholicDrinkFactory = new DrinkFactory(false);
            _menuItemRepository.Add(nonAlcoholicDrinkFactory.CreateMenuItem("Soda", 2.99m, "Drink", 1));
            _menuItemRepository.Add(nonAlcoholicDrinkFactory.CreateMenuItem("Juice", 3.49m, "Drink", 1));
        }
    }
}
