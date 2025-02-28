using Microsoft.AspNetCore.Mvc;
using Moq;
using Sales_Date_Prediction.Controllers;
using SalesDatePrediction_Application.Interfaces;
using SalesDatePrediction_Application.Services;
using SalesDatePrediction_Domain.Models;

namespace SalesDatePrediction_Test.Controllers
{
    public class CustomerControllerTest
    {
        private readonly Mock<ICustomerRepository> _mockCustomersRepository;
        private readonly CustomerService _customerService;
        private readonly CustomersController _customersController;

        public CustomerControllerTest()
        {
            _mockCustomersRepository = new Mock<ICustomerRepository>();
            _customerService = new CustomerService(_mockCustomersRepository.Object);
            _customersController = new CustomersController(_customerService);
        }

        [Fact]
        public async Task GetSaleDatePrediction_ReturnsCustomeInfoPredictionList_AsJson()
        {
            // Arrange
            var testCustomers = new List<CustomerModel>
            {
                new CustomerModel { CustomerId = 1, CustomerName = "Customer A", LastOrderDate = new DateOnly(2025, 1, 12), NextPredictedOrderDate = new DateOnly(2025, 2, 12) },
                new CustomerModel { CustomerId = 2, CustomerName = "Customer B", LastOrderDate = new DateOnly(2025, 1, 15), NextPredictedOrderDate = new DateOnly(2025, 2, 1) }
            };

            _mockCustomersRepository.Setup(s => s.GetPredictedOrders()).ReturnsAsync(testCustomers);

            // Act
            var result = await _customersController.GetSaleDatePrediction();

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            var data = Assert.IsAssignableFrom<IEnumerable<object>>(jsonResult.Value);

            var list = data.ToList();
            Assert.Equal(2, list.Count);

            Assert.Equal(1, list[0].GetType().GetProperty("CustomerId").GetValue(list[0]));
            Assert.Equal("Customer A", list[0].GetType().GetProperty("CustomerName").GetValue(list[0]));
            Assert.Equal(new DateOnly(2025, 1, 12), list[0].GetType().GetProperty("LastOrderDate").GetValue(list[0]));
            Assert.Equal(new DateOnly(2025, 2, 12), list[0].GetType().GetProperty("NextPredictedOrderDate").GetValue(list[0]));

            Assert.Equal(2, list[1].GetType().GetProperty("CustomerId").GetValue(list[1]));
            Assert.Equal("Customer B", list[1].GetType().GetProperty("CustomerName").GetValue(list[1]));
            Assert.Equal(new DateOnly(2025, 1, 15), list[1].GetType().GetProperty("LastOrderDate").GetValue(list[1]));
            Assert.Equal(new DateOnly(2025, 2, 1), list[1].GetType().GetProperty("NextPredictedOrderDate").GetValue(list[1]));
        }

        [Fact]
        public async Task GetSaleDatePrediction_ByCustomerName_ReturnsCustomeInfoPredictionList_AsJson()
        {
            // Arrange
            var customerName = "Customer A";
            var testCustomers = new List<CustomerModel>
            {
                new CustomerModel { CustomerId = 1, CustomerName = "Customer A", LastOrderDate = new DateOnly(2025, 1, 12), NextPredictedOrderDate = new DateOnly(2025, 2, 12) },
                new CustomerModel { CustomerId = 2, CustomerName = "Customer B", LastOrderDate = new DateOnly(2025, 1, 15), NextPredictedOrderDate = new DateOnly(2025, 2, 1) }
            };

            _mockCustomersRepository.Setup(s => s.GetPredictedOrders()).ReturnsAsync(testCustomers);

            // Act
            var result = await _customersController.GetSaleDatePredictionByCustomerName(customerName);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            var data = Assert.IsAssignableFrom<IEnumerable<object>>(jsonResult.Value);

            var list = data.ToList();
            Assert.Equal(1, list.Count);

            Assert.Equal(1, list[0].GetType().GetProperty("CustomerId").GetValue(list[0]));
            Assert.Equal("Customer A", list[0].GetType().GetProperty("CustomerName").GetValue(list[0]));
            Assert.Equal(new DateOnly(2025, 1, 12), list[0].GetType().GetProperty("LastOrderDate").GetValue(list[0]));
            Assert.Equal(new DateOnly(2025, 2, 12), list[0].GetType().GetProperty("NextPredictedOrderDate").GetValue(list[0]));
        }
    }
}
