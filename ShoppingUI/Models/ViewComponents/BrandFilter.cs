using Application.Services.ProductServices.ProductFacade;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingUI.Models.ViewComponents
{
    public class BrandFilter : ViewComponent
    {
        private readonly IProductService productService;

        public BrandFilter(IProductService productService)
        {
            this.productService = productService;
        }
        public  IViewComponentResult Invoke()
        {
            var brand =  productService.GetBrandsProduct.GetBrandsProduct();
            return View("BrandFilter", brand);
        }
    }
}
