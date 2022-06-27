using Application.Services.TagsServices.AddTag;
using Application.Services.TagsServices.TagFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.Pages.Tags
{
    public class CreateModel : PageModel
    {
        private readonly ITagService tagService;

        public CreateModel(ITagService tagService)
        {
            this.tagService = tagService;
        }

        [BindProperty]
        public AddTagDto AddTag { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            var result = await tagService.AddTag.AddTagAsync(AddTag);

            if (result)
            {
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
