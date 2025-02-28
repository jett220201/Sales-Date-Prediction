using SalesDatePrediction_Application.Interfaces;
using SalesDatePrediction_Domain.Entities.DB;

namespace SalesDatePrediction_Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetProducts()
        {
            return (List<Product>)await _productRepository.GetAll();
        }
    }
}
