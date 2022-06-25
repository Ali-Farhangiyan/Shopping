using Application.Services.CategoryServices.AddNewCategory;
using Application.Services.CategoryServices.FacadeCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ICategoryService categoryService;

        public CreateModel(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }


        [BindProperty]
        public AddCategoryDto AddCategory { get; set; } = new AddCategoryDto();

        public int? ParentCategoryId { get; set; }


        public void OnGet(int? Id)
        {
            ParentCategoryId = Id;
        }

        public async Task<IActionResult> OnPost()
        
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await categoryService.AddNewCategory.AddCategoryAsync(AddCategory);

            if (result)
            {
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
