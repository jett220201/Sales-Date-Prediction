using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction_Application.Services;
using SalesDatePrediction_Domain.Entities.DB;

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
        public async Task<JsonResult> GetAll()
        {
            List<Employee> employees = await _employeeService.GetEmployees();
            return Json(employees.Select(x => new
            {
                Empid = x.Id,
                FullName = $"{x.FirstName} {x.LastName}"
            }));
        }
    }
}
