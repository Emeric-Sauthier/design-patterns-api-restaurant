namespace RestaurantApi.Observers
{
    public interface ISubject<T>
    {
        void Attach(IRestaurantObserver<T> observer);
        void Detach(IRestaurantObserver<T> observer);
        void Notify(T data);
    }
}
