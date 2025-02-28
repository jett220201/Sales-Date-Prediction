using SalesDatePrediction_Application.Interfaces;
using SalesDatePrediction_Domain.Entities.DB;

namespace SalesDatePrediction_Application.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<List<Employee>> GetEmployees()
        {
            return (List<Employee>)await _employeeRepository.GetAll();
        }
    }
}
