using Microsoft.AspNetCore.Mvc;
using Moq;
using Sales_Date_Prediction.Controllers;
using SalesDatePrediction_Application.Interfaces;
using SalesDatePrediction_Application.Services;
using SalesDatePrediction_Domain.Entities.DB;

namespace SalesDatePrediction_Test.Controllers
{
    public class EmployeeControllerTest
    {
        private readonly Mock<IEmployeeRepository> _mockEmployeeRepository;
        private readonly EmployeeService _employeeService;
        private readonly EmployeesController _employeeController;
        public EmployeeControllerTest()
        {
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _employeeService = new EmployeeService(_mockEmployeeRepository.Object);
            _employeeController = new EmployeesController(_employeeService);
        }

        [Fact]
        public async Task GetAllProducts_ReturnsProductsList_AsJson()
        {
            // Arrange
            var testEmployees = new List<Employee>
            {
                new Employee() { Id = 1, FirstName = "Employee Name A", LastName = "Employee Last Name A"},
                new Employee() { Id = 2, FirstName = "Employee Name B", LastName = "Employee Last Name B"},
                new Employee() { Id = 3, FirstName = "Employee Name C", LastName = "Employee Last Name C"}
            };

            _mockEmployeeRepository.Setup(s => s.GetAll()).ReturnsAsync(testEmployees);

            // Act
            var result = await _employeeController.GetAll();

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            var data = Assert.IsAssignableFrom<IEnumerable<object>>(jsonResult.Value);

            var list = data.ToList();
            Assert.Equal(3, list.Count);

            Assert.Equal(1, list[0].GetType().GetProperty("Empid").GetValue(list[0]));
            Assert.Equal("Employee Name A Employee Last Name A", list[0].GetType().GetProperty("FullName").GetValue(list[0]));

            Assert.Equal(2, list[1].GetType().GetProperty("Empid").GetValue(list[1]));
            Assert.Equal("Employee Name B Employee Last Name B", list[1].GetType().GetProperty("FullName").GetValue(list[1]));

            Assert.Equal(3, list[2].GetType().GetProperty("Empid").GetValue(list[2]));
            Assert.Equal("Employee Name C Employee Last Name C", list[2].GetType().GetProperty("FullName").GetValue(list[2]));
        }
    }
}
