using GeekShopping.web.Models;
using GeekShopping.web.Services;
using GeekShopping.web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }
        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productService.FindAllProducts();
            return View(products);
        }

        public async Task<IActionResult> CreateProduct()
        {
            return View();
        }

        public async Task<IActionResult> CreateProduct(ProductModel model)
        {
            if(ModelState.IsValid)
            {
                var response = await _productService.CreateProduct(model);
                if(response != null)
                {
                    return RedirectToAction(nameof(ProductIndex));  
                }
            }

            return View(model);
        }
    }
}
