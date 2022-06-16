using Application.DTO;
using Domain.Aggregates.PayableAgg.Entities;
using Domain.Aggregates.PayableAgg.Enums;
using Domain.Aggregates.PayableAgg.Repositories;
using Domain.Aggregates.TransactionAgg.Entities;
using Domain.Aggregates.TransactionAgg.Interfaces.Repositories;
using Domain.Aggregates.TransactionAgg.Interfaces.Strategies;
using Domain.Aggregates.TransactionAgg.ValueObjects;

namespace Domain.Aggregates.TransactionAgg.Strategies
{
    public class DebitCardTransactionStrategy : ITransactionStrategy
    {
        private readonly int _fee = 3;

        private readonly ITransactionRepository _transactionRepository;
        private readonly IPayableRepository _payableRepository;

        public DebitCardTransactionStrategy(ITransactionRepository transactionRepository, IPayableRepository payableRepository)
        {
            _transactionRepository = transactionRepository;
            _payableRepository = payableRepository;
        }

        public async Task<Transaction> CreateTransaction(CreateTransactionRequestDTO request)
        {
            var card = new Card(
                number: request.Card.Number,
                holderName: request.Card.Name,
                expDate: request.Card.ExpirationDate,
                cvv: request.Card.Cvv);

            var transaction = new DebitCardTransaction(
                card: card,
                amount: request.Amount,
                description: request.Description);

            var payable = new Payable(
                request.Amount,
                status: StatusPayble.Paid,
                fee: _fee,
                paymentDate: DateTime.UtcNow);

            await _transactionRepository.Save(transaction);
            await _payableRepository.Save(payable);

            return transaction;
        }
    }
}
