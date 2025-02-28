using Microsoft.AspNetCore.Mvc;
using Moq;
using Sales_Date_Prediction.Controllers;
using SalesDatePrediction_Application.Interfaces;
using SalesDatePrediction_Application.Services;
using SalesDatePrediction_Domain.Entities.DB;

namespace SalesDatePrediction_Test.Controllers
{
    public class ShippersControllerTest
    {
        private readonly Mock<IShipperRepository> _mockShipperRepository;
        private readonly ShipperService _shippingService;
        private readonly ShippersController _shippingController;
        public ShippersControllerTest()
        {
            _mockShipperRepository = new Mock<IShipperRepository>();
            _shippingService = new ShipperService(_mockShipperRepository.Object);
            _shippingController = new ShippersController(_shippingService);
        }

        [Fact]
        public async Task GetAllShippers_ReturnsShippersList_AsJson()
        {
            // Arrange
            var testShippers = new List<Shipper>
            { 
                new Shipper() { Id = 1, CompanyName = "Company A", Phone = "123456789"},
                new Shipper() { Id = 2, CompanyName = "Company B", Phone = "234567891"},
                new Shipper() { Id = 3, CompanyName = "Company C", Phone = "345678912"}
            };

            _mockShipperRepository.Setup(s => s.GetAll()).ReturnsAsync(testShippers);
            
            // Act
            var result = await _shippingController.GetAll();

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            var data = Assert.IsAssignableFrom<IEnumerable<object>>(jsonResult.Value);

            var list = data.ToList();
            Assert.Equal(3, list.Count);
            
            Assert.Equal(1, list[0].GetType().GetProperty("Shipperid").GetValue(list[0]));
            Assert.Equal("Company A", list[0].GetType().GetProperty("Companyname").GetValue(list[0]));

            Assert.Equal(2, list[1].GetType().GetProperty("Shipperid").GetValue(list[1]));
            Assert.Equal("Company B", list[1].GetType().GetProperty("Companyname").GetValue(list[1]));

            Assert.Equal(3, list[2].GetType().GetProperty("Shipperid").GetValue(list[2]));
            Assert.Equal("Company C", list[2].GetType().GetProperty("Companyname").GetValue(list[2]));
        }
    }
}
