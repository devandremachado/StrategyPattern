namespace Domain.Aggregates.TransactionAgg.Enums
{
    public class PaymentMethodTypes
    {
        public const string CreditCard = "credit_card";
        public const string DebitCard = "debit_card";

        public static string[] GetValues()
        {
            var values = new string[] {
                CreditCard,
                DebitCard
            };

            return values;
        }
    }
}
