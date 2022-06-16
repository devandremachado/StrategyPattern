namespace Domain.Aggregates.PayableAgg.Enums
{
    public class StatusPayble
    {
        public const string WaitingFunds = "waiting_funds";
        public const string Paid = "paid";

        public static string[] GetValues()
        {
            var values = new string[] {
                WaitingFunds,
                Paid
            };

            return values;
        }
    }
}
