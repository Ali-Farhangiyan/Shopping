using Application.Services.BrandServices.BrandFacade;
using Application.Services.BrandServices.GetBrands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.Pages.Brands
{
    public class IndexModel : PageModel
    {
        private readonly IBrandService brandService;

        public IndexModel(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        public List<GetBrandDto> GetBrands { get; set; }
        public async Task OnGet()
        {
            GetBrands = await brandService.GetAllBrand.GetAllBrandsAsync();
        }
    }
}
