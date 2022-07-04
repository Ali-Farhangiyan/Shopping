using Application.Services.BasketServices.BasketFacade;
using Application.Services.CustomerServices.CustomerFacade;
using Application.Services.OrderServices.OrderFacade;
using Domain.Entites.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingUI.Models.ViewModels;
using ShoppingUI.Utilities;

namespace ShoppingUI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IBasketService basketService;
        private readonly ICustomerService customerService;
        private readonly IOrderService orderService;

        public OrderController(IBasketService basketService,
            ICustomerService customerService,
            IOrderService orderService)
        {
            this.basketService = basketService;
            this.customerService = customerService;
            this.orderService = orderService;
        }

        public async Task<IActionResult> ShippingPayment()
        {
            var userId = ClaimUtility.GetUserId(User);
            var model = new OrderViewModels();
            model.Basket = await basketService.GetBasket.ExecutAsync(userId);
            model.Addresses = await customerService.GetAddress.ExecuteAsync(userId);
            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> ShippingPayment(int addressId, PaymentMethode paymentMethode)
        {
            var userId = ClaimUtility.GetUserId(User);

            var orderid = await orderService.CreateOrder.ExecuteAsync(userId, addressId, paymentMethode);

            return View();
        }
    }
}
