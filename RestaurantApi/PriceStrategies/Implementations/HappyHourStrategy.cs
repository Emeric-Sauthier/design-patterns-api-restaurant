namespace RestaurantApi.PriceStrategies.Implementations
{
    public class HappyHourStrategy : IPriceStrategy
    {
        private readonly decimal _discountPercentage;
        private readonly DateTime _startDateTime;
        private readonly DateTime _endDateTime;
        private readonly DateTime _orderDateTime;

        public HappyHourStrategy(decimal discountPercentage, DateTime startDateTime, DateTime endDateTime, DateTime orderDateTime)
        {
            _discountPercentage = discountPercentage;
            _startDateTime = startDateTime;
            _endDateTime = endDateTime;
            _orderDateTime = orderDateTime;
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
            return _orderDateTime.TimeOfDay >= _startDateTime.TimeOfDay && _orderDateTime.TimeOfDay <= _endDateTime.TimeOfDay;
        }

        public string GetStrategyName()
        {
            return "Happy Hour";
        }
    }
}
