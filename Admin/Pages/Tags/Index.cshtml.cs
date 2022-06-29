using Application.Pagination;
using Application.Services.TagsServices.GetTags;
using Application.Services.TagsServices.TagFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.Pages.Tags
{
    public class IndexModel : PageModel
    {
        private readonly ITagService tagService;

        public IndexModel(ITagService tagService)
        {
            this.tagService = tagService;
        }

        public PaginatedList<TagDto> ListTags { get; set; }
        public async Task OnGet(int pageSize = 10,int pageIndex = 1)
        {
            ListTags =await tagService.GetTag.GetTagsAsync(pageSize, pageIndex);
        }
    }
}
