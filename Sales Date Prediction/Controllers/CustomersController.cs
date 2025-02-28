using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction_Application.Services;
using SalesDatePrediction_Domain.Models;

namespace Sales_Date_Prediction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly CustomerService _customerService;
        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAll")]
        public async Task<JsonResult> GetSaleDatePrediction()
        {
            List<CustomerModel> predictedOrders = await _customerService.GetPredictedOrders();
            return Json(predictedOrders);
        }

        [HttpGet("GetByCustomerName")]
        public async Task<JsonResult> GetSaleDatePredictionByCustomerName(string customerName)
        {
            List<CustomerModel> predictedOrders = await _customerService.GetPredictedOrders();
            return Json(predictedOrders.Where(x => x.CustomerName.Contains(customerName.Trim(), StringComparison.OrdinalIgnoreCase)));
        }
    }
}
