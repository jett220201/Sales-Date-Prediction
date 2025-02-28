using SalesDatePrediction_Application.Interfaces;

namespace SalesDatePrediction_Application.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
    }
}
