using Domain.Aggregates.TransactionAgg.ValueObjects;

namespace Domain.Aggregates.TransactionAgg.Entities
{
    public class DebitCardTransaction : Transaction
    {
        public DebitCardTransaction(Card card, decimal amount, string description, string transactionType) : base(amount, description, transactionType)
        {
            Card = card;
        }

        public Card Card { get; set; }
    }
}
