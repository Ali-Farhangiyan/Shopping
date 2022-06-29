
using Application.Services.ProductServices.PLPProduct;
using Application.Services.ProductServices.ProductFacade;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }


        public async Task<IActionResult> Index(RequestPLPDto request)
        {
            var products = await productService.PLPProducts.ExecuteAsync(request);
            return View(products);
        }

        public async Task<IActionResult> Details(string? Slug)
        {
            var product = await productService.PDPProducts.ExecuteAsync(Slug);
            return View(product);
        }


    }
}
