using Domain.Aggregates.PayableAgg.Repositories;
using Domain.Aggregates.TransactionAgg.Enums;
using Domain.Aggregates.TransactionAgg.Interfaces.Factories;
using Domain.Aggregates.TransactionAgg.Interfaces.Repositories;
using Domain.Aggregates.TransactionAgg.Interfaces.Strategies;
using Domain.Aggregates.TransactionAgg.Strategies;

namespace Domain.Aggregates.TransactionAgg.Factories
{
    public class TransactionStrategyFactory : ITransactionStrategyFactory
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IPayableRepository _payableRepository;

        public TransactionStrategyFactory(ITransactionRepository transactionRepository, IPayableRepository payableRepository)
        {
            _transactionRepository = transactionRepository;
            _payableRepository = payableRepository;
        }

        public ITransactionStrategy GetStrategy(string paymentMethod)
        {
            return paymentMethod switch
            {
                PaymentMethodTypes.DebitCard => new DebitCardTransactionStrategy(_transactionRepository, _payableRepository),
                PaymentMethodTypes.CreditCard => new CreditCardTransactionStrategy(_transactionRepository, _payableRepository),

                _ => throw new Exception("Invalid payment method"),
            };
        }
    }
}
