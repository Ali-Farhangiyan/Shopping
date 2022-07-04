using Application.ImageServices.FacadeImage;
using Application.Interfaces;
using Application.Services.BasketServices.GetOrCreateBasketForUser;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.BasketServices.GetBasketForUser
{
    public interface IGetBasketForUserService
    {
        Task<BasketDto> ExecutAsync(string buyerId);
    }



    public class GetBasketForUserService : IGetBasketForUserService
    {
        private readonly IDatabaseContext db;
        private readonly IImageService imageServices;

        public GetBasketForUserService(IDatabaseContext db,
            IImageService imageServices)
        {
            this.db = db;
            this.imageServices = imageServices;
        }
        public async Task<BasketDto> ExecutAsync(string buyerId)
        {
            var basket = await db.Baskets
                .Include(b => b.BasketItems)
                .ThenInclude(bi => bi.Product)
                .ThenInclude(p => p.Images)
                .FirstOrDefaultAsync(b => b.BuyerId == buyerId);

            if (basket is null)
            {
                return null;
            }

            return new BasketDto
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                TotalPrice = basket.BasketItems.Sum(b => b.Price * b.Quantity),
                BasketItems = basket.BasketItems.Select(item => new BasketItemDto
                {
                    Id = item.Id,
                    Price = item.Price,
                    ProductId = item.ProductId,
                    ProductName = item.Product.Name,
                    Quantity = item.Quantity,

                    ImageUrl = imageServices.ImageComposer
                        .Execute(item?.Product?.Images?.FirstOrDefault()?.Src ?? "")
                }).ToList()
            };

        }
    }
}
