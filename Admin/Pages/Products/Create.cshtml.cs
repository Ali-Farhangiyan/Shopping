using Application.ImageServices.FacadeImage;
using Application.Services.ProductServices.AddNewProduct;
using Application.Services.ProductServices.GetCategoriesProduct;
using Application.Services.ProductServices.GetTagsProduct;
using Application.Services.ProductServices.ProductFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Admin.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductService productService;
        private readonly IImageService imageService;

        public CreateModel(IProductService productService,
            IImageService imageService)
        {
            this.productService = productService;
            this.imageService = imageService;
        }

        [BindProperty]
        public AddProductDto Data { get; set; }
        [BindProperty]
        public List<IFormFile> Files { get; set; }
        public SelectList GetCategories { get; set; }
        public SelectList GetTags { get; set; }
        public SelectList GetBrands { get; set; }


        public async Task OnGet()
        {
            // GetCategories = await productService.GetCategoriesProduct.GetCategoriesProductAsync();

            GetCategories = new SelectList( productService.GetCategoriesProduct.GetCategoriesProduct(),"Id","Name");
            GetTags = new SelectList(await productService.GetTagsProduct.GetTagsAsync(),"Id","Name");
            GetBrands = new SelectList(productService.GetBrandsProduct.GetBrandsProduct(), "Id", "Name");
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var files = Request.Form.Files;
            
            foreach (var file in files)
            {
                if(file is not null && file.Length > 0)
                {
                    Files.Add(file);
                }
            }

            var results =await imageService.ImageUploader.Execute(Files);
            var images = new List<ImageDto>();

            foreach (var item in results)
            {
                images.Add(new ImageDto { Src = item});
            }

            Data.Images = images;
            var data = await productService.AddProduct.AddProductAsync(Data);
            if (data)
            {
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
