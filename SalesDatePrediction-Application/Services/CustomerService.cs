using SalesDatePrediction_Application.Interfaces;
using SalesDatePrediction_Domain.Models;


namespace SalesDatePrediction_Application.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerModel>> GetPredictedOrders()
        {
            return await _customerRepository.GetPredictedOrders();
        }
    }
}
