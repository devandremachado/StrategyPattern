using Domain.Aggregates.TransactionAgg.Interfaces.Strategies;

namespace Domain.Aggregates.TransactionAgg.Interfaces.Factories
{
    public interface ITransactionStrategyFactory
    {
        public ITransactionStrategy GetStrategy(string paymentMethod);
    }
}
