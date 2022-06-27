using Application.Pagination;
using Application.Services.ProductServices.ProductFacade;
using Application.Services.ProductServices.ShowProducts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductService productService;

        public IndexModel(IProductService productService)
        {
            this.productService = productService;
        }

        public PaginatedList<ShowProductDto> GetAllProducts { get; set; }
        public async Task OnGet(int pageSize=1,int pageIndex=1)
        {
            GetAllProducts = await productService.ShowProducts.ShowProductsAsync(pageSize, pageIndex);
        }
    }
}
