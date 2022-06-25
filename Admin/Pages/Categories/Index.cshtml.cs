using Application.Pagination;
using Application.Services.CategoryServices.FacadeCategory;
using Application.Services.CategoryServices.GetCategories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.Pages.Categories
{

    public class IndexModel : PageModel
    {
        private readonly ICategoryService categoryService;

        public IndexModel(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public PaginatedList<CategoryDto> CategoryList { get; set; }
        public async Task OnGet(int? Id, int pageSize = 1, int pageIndex = 1)
        {
            CategoryList = await categoryService.GetAllCategories.GetCategoriesAsync(Id,pageSize,pageIndex);
        }
    }
}
