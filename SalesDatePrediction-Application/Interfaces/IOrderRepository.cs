using SalesDatePrediction_Domain.Entities.DB;

namespace SalesDatePrediction_Application.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<List<Order>> GetOrders(int customerId);
    }
}
