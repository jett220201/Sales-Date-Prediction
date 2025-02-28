using Microsoft.EntityFrameworkCore;
using SalesDatePrediction_Application.Interfaces;
using SalesDatePrediction_Domain.Entities.DB;
using SalesDatePrediction_Infraestructure.Persistence;

namespace SalesDatePrediction_Infraestructure.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly IDbContextFactory<CoreDBContext> _contextFactory;
        public OrderRepository(IDbContextFactory<CoreDBContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Order>> GetOrders(int customerId)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            return await context.Orders
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
        }
    }
}
