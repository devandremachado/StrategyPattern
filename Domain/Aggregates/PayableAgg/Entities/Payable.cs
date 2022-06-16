namespace Domain.Aggregates.PayableAgg.Entities
{
    public class Payable
    {
        public Payable(decimal amount, double fee, string status, DateTime paymentDate)
        {
            Amount = amount;
            Fee = fee;
            Status = status;
            PaymentDate = paymentDate;

            CalculateAmountWithFee();
        }

        public decimal Amount { get; private set; }
        public double Fee { get; private set; }
        public string Status { get; private set; }
        public DateTime PaymentDate { get; private set; }

        private void CalculateAmountWithFee()
        {
            var total = (decimal)Fee / 100 * Amount;
            Amount -= total;
        }
    }
}
