namespace RestaurantApi.Observers
{
    public interface IRestaurantObserver<T>
    {
        void Update(T data);
    }
}
