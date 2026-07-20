namespace RestaurantApi.Models
{
    public class Order
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int TableNumber { get; set; }
        public List<MenuItem> Items { get; set; } = new();
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = "Received";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string PriceStrategy { get; set; } = "Unknown";

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
