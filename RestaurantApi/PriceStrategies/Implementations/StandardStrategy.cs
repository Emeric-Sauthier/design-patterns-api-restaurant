namespace RestaurantApi.PriceStrategies.Implementations
{
    public class StandardStrategy : IPriceStrategy
    {
        public decimal CalculatePrice(decimal basePrice)
        {
            return basePrice;
        }

        public bool IsApplicable(decimal basePrice) => true;

        public string GetStrategyName()
        {
            return "Standard";
        }
    }
}
