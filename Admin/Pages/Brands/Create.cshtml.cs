using Application.Services.BrandServices.AddNewBrand;
using Application.Services.BrandServices.BrandFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.Pages.Brands
{
    public class CreateModel : PageModel
    {
        private readonly IBrandService brandService;

        public CreateModel(IBrandService brandService)
        {
            this.brandService = brandService;
        }


        [BindProperty]
        public AddBrandDto AddBrand { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await brandService.AddNewBrands.AddBrandAsync(AddBrand);

            if (result)
            {
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
