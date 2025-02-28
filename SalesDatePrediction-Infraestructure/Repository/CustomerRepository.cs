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
            var customers = await context.Customers.Include(x => x.Orders).ToListAsync();
            return customers.Select(x => new CustomerModel
                {
                    CustomerId = x.Id,
                    CustomerName = x.CompanyName,
                    LastOrderDate = x.Orders.Any() ? x.Orders.OrderByDescending(x => x.OrderDate).FirstOrDefault().OrderDate : DateTime.MinValue,
                    NextPredictedOrderDate = GetPredictedDate(x, GetDateAverage(x.Orders.ToList()))
                }).ToList();
        }

        private int GetDateAverage(List<Order> orders)
        {
            if(orders.Count <= 1) return 0;
            return (int)orders.OrderBy(x => x.OrderDate).Select((order, index) =>
            {
                if (index == 0)
                {
                    return (double?)null;
                }
                else
                {
                    return (order.OrderDate - orders[index - 1].OrderDate).TotalDays;
                }
            })
            .Where(x => x.HasValue)
            .Average();
        }

        private DateTime GetPredictedDate(Customer customer, int average)
        {
            if (customer == null) return DateTime.MinValue;
            else if(!customer.Orders.Any()) return DateTime.MinValue;
            else return customer.Orders.OrderByDescending(x => x.OrderDate).FirstOrDefault().OrderDate.AddDays(average);
        }
    }
}
