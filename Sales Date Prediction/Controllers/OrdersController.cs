using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction_Application.Contracts;
using SalesDatePrediction_Application.Services;
using SalesDatePrediction_Domain.Entities.DB;
using Swashbuckle.AspNetCore.Annotations;

namespace Sales_Date_Prediction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly OrderService _orderService;
        private readonly OrderDetailService _orderDetailService;
        public OrdersController(OrderService orderService, OrderDetailService orderDetailService)
        {
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get orders by customer ID", Description = "Retrieve a list of all orders by customer ID")]
        [SwaggerResponse(200, "Returns a list of orders by customer", typeof(List<Order>))]
        [SwaggerResponse(404, "Orders not found")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> GetOrder(int customerId)
        {
            try
            {
                List<Order> orders = await _orderService.GetOrders(customerId);
                if (!orders.Any()) return NotFound("Orders not found");
                return Ok(orders.Select(x => new
                {
                    Orderid = x.Id,
                    Requireddate = x.RequiredDate,
                    Shippeddate = x.ShippedDate,
                    Shipname = x.ShipName,
                    Shipaddress = x.ShipAddress,
                    Shipcity = x.ShipCity
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new order", Description = "Create a new order with details for one specific customer")]
        [SwaggerResponse(200, "Returns the new order ID", typeof(int))]
        [SwaggerResponse(400, "Invalid input parameters")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> CreateOrder([FromBody]CreateOrderDto request)
        {
            try
            {
                if (request.Order == null || request.OrderDetail == null) return BadRequest("Invalid input parameters");
                if (!ModelState.IsValid) return BadRequest(ModelState);
                Order orderDB = await _orderService.AddReturn(request.Order);
                request.OrderDetail.OrderId = orderDB.Id;
                await _orderDetailService.AddReturn(request.OrderDetail);
                return Ok(new
                {
                    Orderid = orderDB.Id,
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
