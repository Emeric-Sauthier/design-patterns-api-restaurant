
namespace RestaurantApi.PriceStrategies.Implementations
{
    public class GroupStrategy : IPriceStrategy
    {
        private readonly decimal _discountPercentage;
        private readonly decimal _minimumPrice;

        public GroupStrategy(decimal discountPercentage, decimal minimumPrice)
        {
            _discountPercentage = discountPercentage;
            _minimumPrice = minimumPrice;
        }

        public decimal CalculatePrice(decimal basePrice)
        {
            if (!IsApplicable(basePrice))
            {
                return basePrice;
            }

            return basePrice * (1 - _discountPercentage / 100);
        }

        public bool IsApplicable(decimal basePrice)
        {
            return basePrice > _minimumPrice;
        }

        public string GetStrategyName()
        {
            return "Group";
        }
    }
}
