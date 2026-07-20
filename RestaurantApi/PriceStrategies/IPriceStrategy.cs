using RestaurantApi.Models;

namespace RestaurantApi.PriceStrategies
{
    public interface IPriceStrategy
    {
        decimal CalculatePrice(decimal basePrice);

        bool IsApplicable(decimal basePrice);

        string GetStrategyName();
    }
}
