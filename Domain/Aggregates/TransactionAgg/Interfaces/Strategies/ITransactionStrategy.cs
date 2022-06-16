using Application.DTO;
using Domain.Aggregates.TransactionAgg.Entities;

namespace Domain.Aggregates.TransactionAgg.Interfaces.Strategies
{
    public interface ITransactionStrategy
    {
        Task<Transaction> CreateTransaction(CreateTransactionRequestDTO request);
    }
}
