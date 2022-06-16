using Application.DTO;
using WebApi.ViewModels.Request;

namespace WebApi.Mappers
{
    public static class TransactionMapper
    {
        public static CreateTransactionRequestDTO MapCreateTransactionToDTO(CreateTransactionRequest request)
        {
            if (request == null)
                return null;

            var response = new CreateTransactionRequestDTO()
            {
                Amount = request.Amount,
                Description = request.Description,
                PaymentMethod = request.PaymentMethod,
                Card = MapCreateCardToDTO(request.Card)
            };

            return response;
        }

        public static CreateCardRequestDTO MapCreateCardToDTO(CreateCardRequest request)
        {
            if (request == null)
                return null;

            var response = new CreateCardRequestDTO()
            {
                Number = request.Number,
                Name = request.Name,
                ExpirationDate = request.ExpirationDate,
                Cvv = request.Cvv
            };

            return response;
        }
    }
}
