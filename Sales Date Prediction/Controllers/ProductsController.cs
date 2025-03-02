using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction_Application.Services;
using SalesDatePrediction_Domain.Entities.DB;
using Swashbuckle.AspNetCore.Annotations;

namespace Sales_Date_Prediction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;
        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all products", Description = "Retrieve a list of all products with ID and Product Name")]
        [SwaggerResponse(200, "Returns a list of all products", typeof(List<Product>))]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Product> products = await _productService.GetProducts();
                return Ok(products.Select(x => new
                {
                    Productid = x.Id,
                    Productname = x.Name,
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
