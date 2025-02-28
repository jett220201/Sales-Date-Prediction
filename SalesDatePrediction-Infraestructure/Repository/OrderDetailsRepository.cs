using Microsoft.EntityFrameworkCore;
using SalesDatePrediction_Application.Interfaces;
using SalesDatePrediction_Domain.Entities.DB;
using SalesDatePrediction_Infraestructure.Persistence;

namespace SalesDatePrediction_Infraestructure.Repository
{
    public class OrderDetailsRepository : GenericRepository<OrderDetail>, IOrderDetailsRepository
    {
        private readonly IDbContextFactory<CoreDBContext> _contextFactory;
        public OrderDetailsRepository(IDbContextFactory<CoreDBContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
