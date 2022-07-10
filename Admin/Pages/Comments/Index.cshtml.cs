using Application.Pagination;
using Application.Services.CommentServices.CommentFacade;
using Application.Services.CommentServices.GetAllComments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.Pages.Comments
{
    public class IndexModel : PageModel
    {
        private readonly ICommentService commentService;

        public IndexModel(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public PaginatedList<GetCommentDto> GetComments { get; set; }

        

        public async Task OnGet(RequestCommentDto Request)
        {
            
            GetComments = await commentService.GetComments.ExecuteAsync(Request);

            ;
        }
    }
}
