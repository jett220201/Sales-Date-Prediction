using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction_Application.Services;
using SalesDatePrediction_Domain.Entities.DB;

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
        public async Task<JsonResult> GetOrder(int customerId)
        {
            List<Order> orders = await _orderService.GetOrders(customerId);
            return Json(orders.Select(x => new
            {
                Orderid = x.Id,
                Requireddate = x.RequiredDate,
                Shippeddate = x.ShippedDate,
                Shipname = x.ShipName,
                Shipaddress = x.ShipAddress,
                Shipcity = x.ShipCity
            }));
        }

        [HttpPost]
        public async Task<JsonResult> CreateOrder(Order order, OrderDetail orderDetail)
        {
            Order orderDB = await _orderService.AddReturn(order);
            orderDetail.OrderId = orderDB.Id;
            await _orderDetailService.AddReturn(orderDetail);
            return Json(new
            {
                Orderid = orderDB.Id,
            });
        }
    }
}
