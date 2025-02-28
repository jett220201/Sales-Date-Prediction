using SalesDatePrediction_Domain.Entities.DB;
using SalesDatePrediction_Domain.Models;

namespace SalesDatePrediction_Application.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<List<CustomerModel>> GetPredictedOrders();
    }
}
