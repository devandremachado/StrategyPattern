using Application.DTO;
using Domain.Aggregates.PayableAgg.Repositories;
using Domain.Aggregates.TransactionAgg.Entities;
using Domain.Aggregates.TransactionAgg.Enums;
using Domain.Aggregates.TransactionAgg.Interfaces.Repositories;
using Domain.Aggregates.TransactionAgg.Interfaces.Services;
using Domain.Aggregates.TransactionAgg.Interfaces.Strategies;
using Domain.Aggregates.TransactionAgg.Strategies;

namespace Domain.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IPayableRepository _payableRepository;

        public TransactionService(ITransactionRepository transactionRepository, IPayableRepository payableRepository)
        {
            _transactionRepository = transactionRepository;
            _payableRepository = payableRepository;
        }

        public async Task<Transaction> CreateTransaction(CreateTransactionRequestDTO request)
        {

            ITransactionStrategy transactionStrategy = request.PaymentMethod switch
            {
                PaymentMethodTypes.DebitCard => new DebitCardTransactionStrategy(_transactionRepository, _payableRepository),
                PaymentMethodTypes.CreditCard => new CreditCardTransactionStrategy(_transactionRepository, _payableRepository),

                _ => throw new Exception("Invalid payment method"),
            };

            var transaction = await transactionStrategy.CreateTransaction(request);
            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactions()
        {
            var transactions = await _transactionRepository.GetAll();
            return transactions;
        }
    }
}
