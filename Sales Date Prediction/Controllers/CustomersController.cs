using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction_Application.Services;
using SalesDatePrediction_Domain.Models;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(Summary = "Get all predicted dates orders", Description = "Retrieve a list of all customer name, last order and predicted next order.")]
        [SwaggerResponse(200, "Returns a list of customer's last and predicted next order", typeof(List<CustomerModel>))]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> GetSaleDatePrediction()
        {
            try
            {
                List<CustomerModel> predictedOrders = await _customerService.GetPredictedOrders();
                return Ok(predictedOrders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetByCustomerName")]
        [SwaggerOperation(Summary = "Get predicted dates orders by customer name", Description = "Retrieve a list of all customer name, last order and predicted next order that match the input name.")]
        [SwaggerResponse(200, "Returns a list of customer's last and predicted next order that match the name", typeof(List<CustomerModel>))]
        [SwaggerResponse(404, "Customer orders not found")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> GetSaleDatePredictionByCustomerName(string customerName)
        {
            try
            {
                List<CustomerModel> predictedOrders = await _customerService.GetPredictedOrders();
                List<CustomerModel> customerOrders = predictedOrders.Where(x => x.CustomerName.Contains(customerName.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
                if(!customerOrders.Any()) return NotFound("Customer orders not found");
                return Ok(customerOrders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
