using Microsoft.EntityFrameworkCore;
using SalesDatePrediction_Application.Interfaces;
using SalesDatePrediction_Domain.Entities.DB;
using SalesDatePrediction_Infraestructure.Persistence;

namespace SalesDatePrediction_Infraestructure.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly IDbContextFactory<CoreDBContext> _contextFactory;
        public CategoryRepository(IDbContextFactory<CoreDBContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
