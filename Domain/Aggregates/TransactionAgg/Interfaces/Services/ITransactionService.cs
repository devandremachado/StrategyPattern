using Application.DTO;
using Domain.Aggregates.TransactionAgg.Entities;

namespace Domain.Aggregates.TransactionAgg.Interfaces.Services
{
    public interface ITransactionService
    {
        Task<Transaction> CreateTransaction(CreateTransactionRequestDTO request);
        Task<IEnumerable<Transaction>> GetAllTransactions();
    }
}
