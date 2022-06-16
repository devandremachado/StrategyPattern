using Domain.Aggregates.PayableAgg.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("payables")]
    [ApiController]
    public class PayablesController : Controller
    {
        private readonly IPayableRepository _payableRepository;

        public PayablesController(IPayableRepository payableRepository)
        {
            _payableRepository = payableRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetByStatus(string status)
        {
            var response = await _payableRepository.GetByStatus(status);
            return Ok(response);
        }
    }
}
