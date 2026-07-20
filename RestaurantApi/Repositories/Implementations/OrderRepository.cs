using RestaurantApi.Models;
using System.Collections.Concurrent;

namespace RestaurantApi.Repositories.Implementations;

public class OrderRepository : IRepository<Order>
{
    private readonly ConcurrentDictionary<string, Order> _orders = new();

    public void Add(Order order)
    {
        _orders[order.Id] = order;
    }

    public Order? GetById(string id)
    {
        return _orders.TryGetValue(id, out var order) ? order : null;
    }

    public IEnumerable<Order> GetAll()
    {
        return _orders.Values.ToList();
    }
}
