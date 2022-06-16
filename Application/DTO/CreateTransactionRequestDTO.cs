namespace Application.DTO
{
    public class CreateTransactionRequestDTO
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string PaymentMethod { get; set; }
        public CreateCardRequestDTO Card { get; set; }
    }

    public class CreateCardRequestDTO
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Cvv { get; set; }
    }
}
