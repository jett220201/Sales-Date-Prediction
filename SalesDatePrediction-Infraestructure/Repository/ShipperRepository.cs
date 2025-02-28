using Microsoft.EntityFrameworkCore;
using SalesDatePrediction_Application.Interfaces;
using SalesDatePrediction_Domain.Entities.DB;
using SalesDatePrediction_Infraestructure.Persistence;

namespace SalesDatePrediction_Infraestructure.Repository
{
    public class ShipperRepository : GenericRepository<Shipper>, IShipperRepository
    {
        private readonly IDbContextFactory<CoreDBContext> _contextFactory;
        public ShipperRepository(IDbContextFactory<CoreDBContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
