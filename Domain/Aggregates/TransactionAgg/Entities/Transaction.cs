namespace Domain.Aggregates.TransactionAgg.Entities
{
    public abstract class Transaction
    {
        public Transaction(decimal amount, string description, string transactionType)
        {
            Amount = amount;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            TransactionType = transactionType;
        }

        public decimal Amount { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public string TransactionType { get; private set; }

    }
}
