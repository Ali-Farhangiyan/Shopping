using Application.Interfaces;
using Application.Services.CommentServices.AcceptComment;
using Application.Services.CommentServices.CommentFacade;
using Application.Services.CommentServices.GetAllComments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.Pages.Comments
{
    public class VerifyModel : PageModel
    {
        private readonly ICommentService commentService;

        public VerifyModel(ICommentService commentService)
        {
            this.commentService = commentService;
        }


        public GetCommentDto GetCommentById { get; set; }

        [BindProperty]
        public AcceptCommentDto Accept { get; set; }
        public async Task OnGet(int Id)
        {
            GetCommentById = await commentService.GetComment.ExecuteAsync(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            await commentService.AcceptComment.ExecuteAsync(Accept);
            return RedirectToPage("Index");
        }
    }
}
