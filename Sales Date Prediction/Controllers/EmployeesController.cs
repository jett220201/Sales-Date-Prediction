using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction_Application.Services;
using SalesDatePrediction_Domain.Entities.DB;
using Swashbuckle.AspNetCore.Annotations;

namespace Sales_Date_Prediction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly EmployeeService _employeeService;
        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all employees", Description = "Retrieve a list of all employees with ID and FullName")]
        [SwaggerResponse(200, "Returns a list of all employees", typeof(List<Employee>))]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Employee> employees = await _employeeService.GetEmployees();
                return Ok(employees.Select(x => new
                {
                    Empid = x.Id,
                    FullName = $"{x.FirstName} {x.LastName}"
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
