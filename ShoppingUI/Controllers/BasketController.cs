using Application.Services.BasketServices.BasketFacade;
using Application.Services.BasketServices.GetOrCreateBasketForUser;
using Microsoft.AspNetCore.Mvc;
using ShoppingUI.Utilities;

namespace ShoppingUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService basketService;
        private readonly IConfiguration configuration;
        private string userId = null;

        public BasketController(IBasketService basketService,
            IConfiguration configuration)
        {
            this.basketService = basketService;
            this.configuration = configuration;
        }



        public async Task<IActionResult> Index()
        {
            var data = await GetOrSetBasket();
            return View(data);
        }



        [HttpPost]
        public async Task<IActionResult> Index(int productId, int quantity = 1)
        {
            var basket = await GetOrSetBasket();
            var result = await basketService.AddItem.ExecutAsync(basket.Id, productId, quantity);
            if(result == true)
            {
                return RedirectToAction(nameof(Index));

            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveItems(int productId)
        {
            var result = await basketService.RemvoeItem.ExecuteAsync(productId);

            if(result == true)
            {
                return RedirectToAction(nameof(Index));
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddQuantites(int productId)
        {
            var result = await basketService.SetQuantity.ExecuteAsync(productId);

            if (result == true)
            {
                return RedirectToAction(nameof(Index));
            }

            return BadRequest();
        }



        private async Task<BasketDto> GetOrSetBasket()
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = ClaimUtility.GetUserId(User);
                return await basketService.GetOrCreateBasket.ExecutAsync(userId);
            }
            else
            {
                setCookies();
                return await basketService.GetOrCreateBasket.ExecutAsync(userId);
            }
        }

        private void setCookies()
        {
            var basketId = configuration["BuyerCookieName"];
            if (Request.Cookies.ContainsKey(basketId))
            {
                userId = Request.Cookies[basketId];
                
            }
            if (userId is not null) return;

            userId = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions { IsEssential = true };
            cookieOptions.Expires = DateTime.Today.AddYears(2);
            Response.Cookies.Append(basketId, userId, cookieOptions);
        }


    }
}
