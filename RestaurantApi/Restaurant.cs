using RestaurantApi.Factories;
using RestaurantApi.Models;
using RestaurantApi.Observers;
using RestaurantApi.PriceStrategies;
using RestaurantApi.PriceStrategies.Implementations;
using RestaurantApi.Repositories.Implementations;

namespace RestaurantApi
{
    public class Restaurant : ISubject<Order>
    {
        private readonly OrderRepository _orderRepository;
        private readonly MenuItemRepository _menuItemRepository;

        private readonly List<IRestaurantObserver<Order>> _orderObservers = new();

        private const decimal HappyHourDiscount = 20m;
        private readonly DateTime HappyHourtStart = new DateTime(1, 1, 1, 15, 0, 0);
        private readonly DateTime HappyHourEnd = new DateTime(1, 1, 1, 19, 0, 0);

        private const decimal GroupDiscountPercentage = 15m;
        private const decimal GroupMinimumOrderAmount = 50m;

        private const decimal MenuPrice = 25m;

        public Restaurant(OrderRepository orderRepository, MenuItemRepository menuItemRepository)
        {
            _orderRepository = orderRepository;
            _menuItemRepository = menuItemRepository;

            InitializeMenu();
        }

        public IEnumerable<MenuItem> GetMenu()
        {
            return _menuItemRepository.GetAll();
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orderRepository.GetAll();
        }

        public Order? GetOrderById(string id)
        {
            return _orderRepository.GetById(id);
        }

        public Order CreateOrder(OrderDto orderDto)
        {
            List<MenuItem> matchingMenuItems = GetMatchingMenuItems(orderDto.ItemsId);

            Order order = new Order(orderDto.TableNumber, matchingMenuItems, orderDto.PriceStrategy ?? string.Empty);

            IPriceStrategy priceStrategy = GetPriceStrategy(order);
            order.PriceStrategy = priceStrategy.GetStrategyName();
            order.TotalPrice = priceStrategy.CalculatePrice(order.TotalPrice);

            _orderRepository.Add(order);
            Notify(order);
            return order;
        }

        public Order? OrderNextState(string orderId)
        {
            Order? order = _orderRepository.GetById(orderId);
            if (order == null) {
                return null;
            }

            order.NextState();
            Notify(order);

            return order;
        }

        private void InitializeMenu()
        {
            var entranceFactory = new EntranceFactory();
            _menuItemRepository.Add(entranceFactory.CreateMenuItem("Bruschetta", 6.99m, 10));
            _menuItemRepository.Add(entranceFactory.CreateMenuItem("Salad", 5.99m, 4));

            var nonVegetarianMainDishFactory = new MainDishFactory(false);
            _menuItemRepository.Add(nonVegetarianMainDishFactory.CreateMenuItem("Grilled Chicken", 12.99m, 15));

            var vegetarianMainDishFactory = new MainDishFactory(true);
            _menuItemRepository.Add(vegetarianMainDishFactory.CreateMenuItem("Vegetarian Pasta", 10.99m, 12));

            var dessertFactory = new DessertFactory();
            _menuItemRepository.Add(dessertFactory.CreateMenuItem("Chocolate Cake", 4.99m, 8));
            _menuItemRepository.Add(dessertFactory.CreateMenuItem("Ice Cream", 3.99m, 5));

            var alcoholicDrinkFactory = new DrinkFactory(true);
            _menuItemRepository.Add(alcoholicDrinkFactory.CreateMenuItem("Beer", 5.99m, 2));
            _menuItemRepository.Add(alcoholicDrinkFactory.CreateMenuItem("Wine", 7.99m, 3));

            var nonAlcoholicDrinkFactory = new DrinkFactory(false);
            _menuItemRepository.Add(nonAlcoholicDrinkFactory.CreateMenuItem("Soda", 2.99m, 1));
            _menuItemRepository.Add(nonAlcoholicDrinkFactory.CreateMenuItem("Juice", 3.49m, 1));
        }

        private IPriceStrategy GetPriceStrategy(Order order)
        {
            IPriceStrategy[] priceStrategies = {
                new HappyHourStrategy(HappyHourDiscount, HappyHourtStart, HappyHourEnd, order.CreatedAt),
                new MenuStrategy(MenuPrice, order.Items),
                new GroupStrategy(GroupDiscountPercentage, GroupMinimumOrderAmount),
                new StandardStrategy()
            };

            IPriceStrategy mostAdvantageousStrategy = priceStrategies.OrderBy(s => s.CalculatePrice(order.TotalPrice)).First(s => s.IsApplicable(order.TotalPrice));
            IPriceStrategy selectedPriceStrategy = priceStrategies.Where(s => s.GetStrategyName() == order.PriceStrategy && s.IsApplicable(order.TotalPrice)).FirstOrDefault(mostAdvantageousStrategy);

            return selectedPriceStrategy;
        }

        private List<MenuItem> GetMatchingMenuItems(List<string> itemsId)
        {
            return _menuItemRepository.GetAll().Where(item => itemsId.Contains(item.Id)).ToList();
        }

        public void Attach(IRestaurantObserver<Order> observer)
        {
            _orderObservers.Add(observer);
        }

        public void Detach(IRestaurantObserver<Order> observer)
        {
            _orderObservers.Remove(observer);
        }

        public void Notify(Order data)
        {
            foreach (IRestaurantObserver<Order> observer in _orderObservers)
            {
                observer.Update(data);
            }
        }
    }
}
