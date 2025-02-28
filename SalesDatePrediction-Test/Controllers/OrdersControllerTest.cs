using Microsoft.AspNetCore.Mvc;
using Moq;
using Sales_Date_Prediction.Controllers;
using SalesDatePrediction_Application.Interfaces;
using SalesDatePrediction_Application.Services;
using SalesDatePrediction_Domain.Entities.DB;

namespace SalesDatePrediction_Test.Controllers
{
    public class OrdersControllerTest
    {
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly Mock<IOrderDetailsRepository> _mockOrderDetailRepository;
        private readonly OrderService _orderService;
        private readonly OrderDetailService _orderDetailService;
        private readonly OrdersController _orderController;
        public OrdersControllerTest()
        {
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockOrderDetailRepository = new Mock<IOrderDetailsRepository>();
            _orderService = new OrderService(_mockOrderRepository.Object);
            _orderDetailService = new OrderDetailService(_mockOrderDetailRepository.Object);
            _orderController = new OrdersController(_orderService, _orderDetailService);
        }

        [Fact]
        public async Task GetAllOrders_ReturnsOrderList_AsJson()
        {
            // Arrange
            int customerId = 1;
            var testOrders = new List<Order>
            {
                new Order { Id = 1, RequiredDate = new DateOnly(2025, 2, 26), ShippedDate = new DateOnly(2025, 2, 27), ShipName = "Ship A", ShipAddress = "Ship Address A", ShipCity = "City A", CustomerId = 1 },
                new Order { Id = 2, RequiredDate = new DateOnly(2025, 2, 25), ShippedDate = new DateOnly(2025, 2, 26), ShipName = "Ship B", ShipAddress = "Ship Address B", ShipCity = "City B", CustomerId = 1 },
                new Order { Id = 3, RequiredDate = new DateOnly(2025, 2, 24), ShippedDate = new DateOnly(2025, 2, 25), ShipName = "Ship C", ShipAddress = "Ship Address C", ShipCity = "City C", CustomerId = 1 }
            };

            _mockOrderRepository.Setup(s => s.GetOrders(customerId)).ReturnsAsync(testOrders);

            // Act
            var result = await _orderController.GetOrder(customerId);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            var data = Assert.IsAssignableFrom<IEnumerable<object>>(jsonResult.Value);

            var list = data.ToList();
            Assert.Equal(3, list.Count);

            Assert.Equal(1, list[0].GetType().GetProperty("Orderid").GetValue(list[0]));
            Assert.Equal(new DateOnly(2025, 2, 26), list[0].GetType().GetProperty("Requireddate").GetValue(list[0]));
            Assert.Equal(new DateOnly(2025, 2, 27), list[0].GetType().GetProperty("Shippeddate").GetValue(list[0]));
            Assert.Equal("Ship A", list[0].GetType().GetProperty("Shipname").GetValue(list[0]));
            Assert.Equal("Ship Address A", list[0].GetType().GetProperty("Shipaddress").GetValue(list[0]));
            Assert.Equal("City A", list[0].GetType().GetProperty("Shipcity").GetValue(list[0]));

            Assert.Equal(2, list[1].GetType().GetProperty("Orderid").GetValue(list[1]));
            Assert.Equal(new DateOnly(2025, 2, 25), list[1].GetType().GetProperty("Requireddate").GetValue(list[1]));
            Assert.Equal(new DateOnly(2025, 2, 26), list[1].GetType().GetProperty("Shippeddate").GetValue(list[1]));
            Assert.Equal("Ship B", list[1].GetType().GetProperty("Shipname").GetValue(list[1]));
            Assert.Equal("Ship Address B", list[1].GetType().GetProperty("Shipaddress").GetValue(list[1]));
            Assert.Equal("City B", list[1].GetType().GetProperty("Shipcity").GetValue(list[1]));

            Assert.Equal(3, list[2].GetType().GetProperty("Orderid").GetValue(list[2]));
            Assert.Equal(new DateOnly(2025, 2, 24), list[2].GetType().GetProperty("Requireddate").GetValue(list[2]));
            Assert.Equal(new DateOnly(2025, 2, 25), list[2].GetType().GetProperty("Shippeddate").GetValue(list[2]));
            Assert.Equal("Ship C", list[2].GetType().GetProperty("Shipname").GetValue(list[2]));
            Assert.Equal("Ship Address C", list[2].GetType().GetProperty("Shipaddress").GetValue(list[2]));
            Assert.Equal("City C", list[2].GetType().GetProperty("Shipcity").GetValue(list[2]));
        }

        [Fact]
        public async Task PostNewOrder_ReturnsNewOrderId_AsJson()
        {
            // Arrange
            var testOrder = new Order { 
                Id = 1, 
                RequiredDate = new DateOnly(2025, 2, 26), 
                ShippedDate = new DateOnly(2025, 2, 27), 
                ShipName = "Ship A", 
                ShipAddress = "Ship Address A", 
                ShipCity = "City A", 
                ShipRegion = "Region A",
                ShipPostalCode = "762522",
                ShipCountry = "Country A",
                CustomerId = 1,
                EmployeeId = 1,
                OrderDate = new DateOnly(2025, 2, 25),
                ShipperId = 1,
                Freight = 10
            };

            var testOrderDetail = new OrderDetail
            {
                OrderId = 1,
                ProductId = 1,
                Price = 100,
                Quantity = 1,
                Discount = 10,
            };

            _mockOrderRepository.Setup(s => s.AddReturn(testOrder)).ReturnsAsync(testOrder);
            _mockOrderDetailRepository.Setup(s => s.AddReturn(testOrderDetail)).ReturnsAsync(testOrderDetail);

            // Act
            var result = await _orderController.CreateOrder(testOrder, testOrderDetail);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            var data = Assert.IsAssignableFrom<object>(jsonResult.Value);

            Assert.Equal(1, data.GetType().GetProperty("Orderid").GetValue(data));
        }
    }
}
