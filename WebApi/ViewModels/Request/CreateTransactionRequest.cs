namespace WebApi.ViewModels.Request
{
    public class CreateTransactionRequest
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string PaymentMethod { get; set; }
        public CreateCardRequest Card { get; set; }
    }

    public class CreateCardRequest
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Cvv { get; set; }
    }
}
