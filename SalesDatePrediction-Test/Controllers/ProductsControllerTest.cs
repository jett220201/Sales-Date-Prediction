using Microsoft.AspNetCore.Mvc;
using Moq;
using Sales_Date_Prediction.Controllers;
using SalesDatePrediction_Application.Interfaces;
using SalesDatePrediction_Application.Services;
using SalesDatePrediction_Domain.Entities.DB;

namespace SalesDatePrediction_Test.Controllers
{
    public class ProductsControllerTest
    {
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly ProductService _productService;
        private readonly ProductsController _productController;
        public ProductsControllerTest()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _productService = new ProductService(_mockProductRepository.Object);
            _productController = new ProductsController(_productService);
        }

        [Fact]
        public async Task GetAllProducts_ReturnsProductsList_AsJson()
        {
            // Arrange
            var testProducts = new List<Product>
            {
                new Product() { Id = 1, Name = "Product A", Price = 10, Discontinued = false},
                new Product() { Id = 2, Name = "Product B", Price = 20, Discontinued = false},
                new Product() { Id = 3, Name = "Product C", Price = 30, Discontinued = false}
            };

            _mockProductRepository.Setup(s => s.GetAll()).ReturnsAsync(testProducts);

            // Act
            var result = await _productController.GetAll();

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            var data = Assert.IsAssignableFrom<IEnumerable<object>>(jsonResult.Value);

            var list = data.ToList();
            Assert.Equal(3, list.Count);

            Assert.Equal(1, list[0].GetType().GetProperty("Productid").GetValue(list[0]));
            Assert.Equal("Product A", list[0].GetType().GetProperty("Productname").GetValue(list[0]));

            Assert.Equal(2, list[1].GetType().GetProperty("Productid").GetValue(list[1]));
            Assert.Equal("Product B", list[1].GetType().GetProperty("Productname").GetValue(list[1]));

            Assert.Equal(3, list[2].GetType().GetProperty("Productid").GetValue(list[2]));
            Assert.Equal("Product C", list[2].GetType().GetProperty("Productname").GetValue(list[2]));
        }
    }
}
