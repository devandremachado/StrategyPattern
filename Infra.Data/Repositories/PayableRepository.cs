using Domain.Aggregates.PayableAgg.Entities;
using Domain.Aggregates.PayableAgg.Repositories;

namespace Infra.Data.Repositories
{
    public class PayableRepository : IPayableRepository
    {
        private readonly List<Payable> _payables;

        public PayableRepository()
        {
            _payables = new List<Payable>();
        }

        public async Task Save(Payable payable)
        {
            await Task.CompletedTask;
            _payables.Add(payable);
        }

        public async Task<IEnumerable<Payable>> GetAll()
        {
            await Task.CompletedTask;
            return _payables.ToList();
        }

        public async Task<IEnumerable<Payable>> GetByStatus(string status)
        {
            await Task.CompletedTask;
            return _payables
                .Where(x => x.Status == status)
                .ToList();
        }
    }
}
