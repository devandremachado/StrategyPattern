using Domain.Aggregates.TransactionAgg.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using WebApi.Mappers;
using WebApi.ViewModels.Request;

namespace WebApi.Controllers
{
    [Route("transactions")]
    [ApiController]
    public class TransactionsController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction(CreateTransactionRequest request)
        {
            var requestDto = TransactionMapper.MapCreateTransactionToDTO(request);

            var response = await _transactionService.CreateTransaction(requestDto);
            return Ok(response);
        }

        [Route("all-transactions")]
        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var response = await _transactionService.GetAllTransactions();

            return Ok(response);
        }

        [Route("first-transaction")]
        [HttpGet]
        public async Task<IActionResult> GetFirstTransaction()
        {
            var response = await _transactionService.GetFirstTransaction();

            return Ok(response);
        }
    }
}
