using Domain.Aggregates.TransactionAgg.Entities;
using Domain.Aggregates.TransactionAgg.Interfaces.Repositories;

namespace Infra.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly List<Transaction> _transactions;

        public TransactionRepository()
        {
            _transactions = new List<Transaction>();
        }

        public async Task Save(Transaction transaction)
        {
            await Task.CompletedTask;
            _transactions.Add(transaction);
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            await Task.CompletedTask;
            return _transactions.ToList();
        }

        public async Task<Transaction> GetFirstTransaction()
        {
            await Task.CompletedTask;
            return _transactions.FirstOrDefault();
        }
    }
}
