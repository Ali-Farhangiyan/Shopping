
using Application.Services.CommentServices.AddNewComment;
using Application.Services.CommentServices.CommentFacade;
using Application.Services.ProductServices.PLPProduct;
using Application.Services.ProductServices.ProductFacade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingUI.Utilities;

namespace ShoppingUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICommentService commentService;

        public ProductController(IProductService productService, ICommentService commentService)
        {
            this.productService = productService;
            this.commentService = commentService;
        }


        public async Task<IActionResult> Index(RequestPLPDto request)
        {
            var products = await productService.PLPProducts.ExecuteAsync(request);
            return View(products);
        }

        public async Task<IActionResult> Details(string? Slug)
        {
            string? userId = null;
            if (User.Identity.IsAuthenticated)
            {
                userId = ClaimUtility.GetUserId(User);
            }

            var product = await productService.PDPProducts.ExecuteAsync(Slug,userId);

            return View(product);
        }


        [Authorize]
        [Route("~/favo")]
        [HttpPost]
        public async Task<IActionResult> FavoriteOperation(bool isFavorite,int productId, string slug)
        {
            var userId = ClaimUtility.GetUserId(User);
            
            if(isFavorite == true)
            {
                await productService.FavoriteProducts.AddToFavoriteAsync(userId, productId);
                return RedirectToAction(nameof(Details), new {Slug=slug});
            }
            else
            {
                await productService.FavoriteProducts.RemoveFromFavoriteAsync(userId, productId);
                return RedirectToAction(nameof(Details), new { Slug = slug });
            }
        }


        [Authorize]
        [Route("~/addcomment")]
        [HttpPost]
        public async Task<IActionResult> AddComment(AddNewCommentDto comment, string slug)
        {
            var userid = ClaimUtility.GetUserId(User);
            await commentService.AddComment.ExecuteAsync(comment, userid);

            return RedirectToAction(nameof(Details), new { Slug = slug });
        }

        
    }
}
