namespace Domain.Aggregates.TransactionAgg.ValueObjects
{
    public class Card
    {
        public Card(string number, string holderName, DateTime expDate, string cvv)
        {
            Number = number;
            HolderName = holderName;
            ExpDate = expDate;
            Cvv = cvv;
        }

        public string Number { get; private set; }
        public string HolderName { get; private set; }
        public DateTime ExpDate { get; private set; }
        public string Cvv { get; private set; }

        public string LastFourDigits => Number[^4..];
        public int ExpMonth => ExpDate.Month;
        public int ExpYear => ExpDate.Year;
    }
}
