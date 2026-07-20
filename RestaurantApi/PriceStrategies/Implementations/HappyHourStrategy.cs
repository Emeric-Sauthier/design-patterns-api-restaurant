namespace RestaurantApi.PriceStrategies.Implementations
{
    public class HappyHourStrategy : IPriceStrategy
    {
        private readonly decimal _discountPercentage;
        private readonly DateTime _startDateTime;
        private readonly DateTime _endDateTime;

        public HappyHourStrategy(decimal discountPercentage, DateTime startDateTime, DateTime endDateTime)
        {
            _discountPercentage = discountPercentage;
            _startDateTime = startDateTime;
            _endDateTime = endDateTime;
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
            var currentTime = DateTime.Now;
            return currentTime.TimeOfDay >= _startDateTime.TimeOfDay && currentTime.TimeOfDay <= _endDateTime.TimeOfDay;
        }

        public string GetStrategyName()
        {
            return "Happy Hour";
        }
    }
}
