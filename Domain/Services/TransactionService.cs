using Application.DTO;
using Domain.Aggregates.TransactionAgg.Entities;
using Domain.Aggregates.TransactionAgg.Interfaces.Factories;
using Domain.Aggregates.TransactionAgg.Interfaces.Repositories;
using Domain.Aggregates.TransactionAgg.Interfaces.Services;

namespace Domain.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransactionStrategyFactory _transactionStrategyFactory;

        public TransactionService(ITransactionRepository transactionRepository, ITransactionStrategyFactory transactionStrategyFactory)
        {
            _transactionRepository = transactionRepository;
            _transactionStrategyFactory = transactionStrategyFactory;
        }

        public async Task<Transaction> CreateTransaction(CreateTransactionRequestDTO request)
        {
            var transactionStrategy = _transactionStrategyFactory.GetStrategy(request.PaymentMethod);

            var transaction = await transactionStrategy.CreateTransaction(request);

            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactions()
        {
            var transactions = await _transactionRepository.GetAll();
            return transactions;
        }

        public async Task<Transaction> GetFirstTransaction()
        {
            var transaction = await _transactionRepository.GetFirstTransaction();
            return transaction;
        }
    }
}
