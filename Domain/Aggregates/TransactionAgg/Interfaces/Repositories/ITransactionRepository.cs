using Domain.Aggregates.TransactionAgg.Entities;

namespace Domain.Aggregates.TransactionAgg.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        Task Save(Transaction transaction);
        Task<IEnumerable<Transaction>> GetAll();
    }
}
