using Microsoft.EntityFrameworkCore;
using SalesDatePrediction_Application.Interfaces;
using SalesDatePrediction_Domain.Entities.DB;
using SalesDatePrediction_Domain.Models;
using SalesDatePrediction_Infraestructure.Persistence;

namespace SalesDatePrediction_Infraestructure.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly IDbContextFactory<CoreDBContext> _contextFactory;
        public CustomerRepository(IDbContextFactory<CoreDBContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<CustomerModel>> GetPredictedOrders()
        {
            var context = await _contextFactory.CreateDbContextAsync();
            return await context.Customers.Include(x => x.Orders)
                .Select(x => new CustomerModel
                {
                    CustomerId = x.Id,
                    CustomerName = x.CompanyName,
                    LastOrderDate = x.Orders.OrderByDescending(x => x.OrderDate).FirstOrDefault().OrderDate,
                    NextPredictedOrderDate = GetPredictedDate(x, GetDateAverage((List<Order>)x.Orders))
                }).ToListAsync();
        }

        private int GetDateAverage(List<Order> orders)
        {
            if(!orders.Any()) return 0;
            return (int)orders.OrderBy(x => x.OrderDate).Select((order, index) =>
            {
                if (index == 0)
                {
                    return (double?)null;
                }
                else
                {
                    return (order.OrderDate.ToDateTime(TimeOnly.MinValue) - orders[index - 1].OrderDate.ToDateTime(TimeOnly.MinValue)).TotalDays;
                }
            })
            .Where(x => x.HasValue)
            .Average();
        }

        private DateOnly GetPredictedDate(Customer customer, int average)
        {
            if (customer == null) return DateOnly.MinValue;
            else if(!customer.Orders.Any()) return DateOnly.MinValue;
            else return customer.Orders.OrderByDescending(x => x.OrderDate).FirstOrDefault().OrderDate.AddDays(average);
        }
    }
}
