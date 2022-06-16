using Domain.Aggregates.TransactionAgg.ValueObjects;

namespace Domain.Aggregates.TransactionAgg.Entities
{
    public class CreditCardTransaction : Transaction
    {
        public CreditCardTransaction(Card card, decimal amount, string description) : base(amount, description)
        {
            Card = card;
        }

        public Card Card { get; set; }
    }
}
