using RestaurantApi.Models;

namespace RestaurantApi.Repositories;

public class MenuItemRepository
{
    private readonly Dictionary<string, MenuItem> _menuItems = new();

    public void Add(MenuItem menuItem)
    {
        _menuItems[menuItem.Id] = menuItem;
    }

    public MenuItem? GetById(string id)
    {
        return _menuItems.TryGetValue(id, out var menuItem) ? menuItem : null;
    }

    public List<MenuItem> GetAll()
    {
        return _menuItems.Values.ToList();
    }
}
