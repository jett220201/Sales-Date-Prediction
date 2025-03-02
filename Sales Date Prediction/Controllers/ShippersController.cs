using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction_Application.Services;
using SalesDatePrediction_Domain.Entities.DB;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(Summary = "Get all shippers", Description = "Retrieve a list of all shippers with ID and Company Name")]
        [SwaggerResponse(200, "Returns a list of all shippers", typeof(List<Shipper>))]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Shipper> shippers = await _shippingService.GetShippers();
                return Ok(shippers.Select(x => new
                {
                    Shipperid = x.Id,
                    Companyname = x.CompanyName
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
