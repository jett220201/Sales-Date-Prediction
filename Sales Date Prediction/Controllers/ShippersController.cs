using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction_Application.Services;
using SalesDatePrediction_Domain.Entities.DB;

namespace Sales_Date_Prediction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShippersController : Controller
    {
        private readonly ShipperService _shippingService;
        public ShippersController(ShipperService shipperService)
        {
            _shippingService = shipperService;
        }

        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            List<Shipper> shippers = await _shippingService.GetShippers();
            return Json(shippers.Select(x => new
            {
                Shipperid = x.Id,
                Companyname = x.CompanyName
            }));
        }
    }
}
