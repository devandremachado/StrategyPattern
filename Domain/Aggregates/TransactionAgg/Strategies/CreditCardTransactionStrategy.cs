using Application.DTO;
using Domain.Aggregates.PayableAgg.Entities;
using Domain.Aggregates.PayableAgg.Enums;
using Domain.Aggregates.PayableAgg.Repositories;
using Domain.Aggregates.TransactionAgg.Entities;
using Domain.Aggregates.TransactionAgg.Enums;
using Domain.Aggregates.TransactionAgg.Interfaces.Repositories;
using Domain.Aggregates.TransactionAgg.Interfaces.Strategies;
using Domain.Aggregates.TransactionAgg.ValueObjects;

namespace Domain.Aggregates.TransactionAgg.Strategies
{
    public class CreditCardTransactionStrategy : ITransactionStrategy
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IPayableRepository _payableRepository;

        public CreditCardTransactionStrategy(ITransactionRepository transactionRepository, IPayableRepository payableRepository)
        {
            _transactionRepository = transactionRepository;
            _payableRepository = payableRepository;
        }

        public async Task<Transaction> CreateTransaction(CreateTransactionRequestDTO request)
        {
            const int FEE = 5;

            var card = new Card(
                number: request.Card.Number,
                holderName: request.Card.HolderName,
                expDate: request.Card.ExpDate,
                cvv: request.Card.Cvv);

            var transaction = new CreditCardTransaction(
                card: card,
                amount: request.Amount,
                description: request.Description,
                transactionType: PaymentMethodTypes.CreditCard);

            var payable = new Payable(
                request.Amount,
                status: StatusPayble.WaitingFunds,
                fee: FEE,
                paymentDate: DateTime.UtcNow.AddDays(30));

            await _transactionRepository.Save(transaction);
            await _payableRepository.Save(payable);

            return transaction;
        }
    }
}
