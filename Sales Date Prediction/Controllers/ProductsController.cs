using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction_Application.Services;
using SalesDatePrediction_Domain.Entities.DB;

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
        public async Task<JsonResult> GetAll()
        {
            List<Product> products = await _productService.GetProducts();
            return Json(products.Select(x => new
            {
                Productid = x.Id,
                Productname = x.Name,
            }));
        }
    }
}
