using Domain.Aggregates.PayableAgg.Entities;

namespace Domain.Aggregates.PayableAgg.Repositories
{
    public interface IPayableRepository
    {
        Task Save(Payable transaction);
        Task<IEnumerable<Payable>> GetAll();
        Task<IEnumerable<Payable>> GetByStatus(string status);
    }
}
