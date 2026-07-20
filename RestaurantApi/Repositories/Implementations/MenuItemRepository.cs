using RestaurantApi.Models;
using System.Collections.Concurrent;

namespace RestaurantApi.Repositories.Implementations;

public class MenuItemRepository : IRepository<MenuItem>
{
    private readonly ConcurrentDictionary<string, MenuItem> _menuItems = new();

    public void Add(MenuItem menuItem)
    {
        _menuItems[menuItem.Id] = menuItem;
    }

    public MenuItem? GetById(string id)
    {
        return _menuItems.TryGetValue(id, out var menuItem) ? menuItem : null;
    }

    public IEnumerable<MenuItem> GetAll()
    {
        return _menuItems.Values.ToList();
    }
}
