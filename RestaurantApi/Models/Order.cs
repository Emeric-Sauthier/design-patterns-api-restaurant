using RestaurantApi.OrderStates;
using RestaurantApi.OrderStates.Implementations;

namespace RestaurantApi.Models
{
    public class Order
    {
        private OrderState _state;

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int TableNumber { get; set; }
        public List<MenuItem> Items { get; set; } = new();
        public decimal TotalPrice { get; set; }
        public string Status => _state.GetStateName();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string PriceStrategy { get; set; } = "Unknown";

        public Order(int tableNumber, List<MenuItem> items, string priceStrategy)
        {
            TableNumber = tableNumber;
            Items = items;
            PriceStrategy = priceStrategy;
            TotalPrice = items.Sum(item => item.Price);
            _state = new OrderReceived(this);
        }

        public void SetState(OrderState state)
        {
            _state = state;
        }

        public void AddItem(MenuItem item)
        {
            Items.Add(item);
        }
    }

    public record OrderDto
    {
        public int TableNumber { get; init; }

        public List<string> ItemsId { get; init; } = new();

        public string? PriceStrategy { get; init; } = null;
    }
}
