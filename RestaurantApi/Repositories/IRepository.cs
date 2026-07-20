namespace RestaurantApi.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T? GetById(string id);

        void Add(T item);
    }
}
