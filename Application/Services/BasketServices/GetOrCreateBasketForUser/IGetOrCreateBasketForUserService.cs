using Application.Interfaces;
using Domain.Entites.Baskets;
using Microsoft.EntityFrameworkCore;
using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ImageServices.FacadeImage;
using System.Runtime.CompilerServices;

namespace Application.Services.BasketServices.GetOrCreateBasketForUser
{
    public interface IGetOrCreateBasketForUserService
    {
        Task<BasketDto> ExecutAsync(string buyerId);
    }

    public class GetOrCreateBasketForUserService : IGetOrCreateBasketForUserService
    {
        private readonly IDatabaseContext db;
        private readonly IImageService imageServices;

        public GetOrCreateBasketForUserService(IDatabaseContext db,
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
                return await CreateBasketForUser(buyerId);
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
                        .Execute( item?.Product?.Images?.FirstOrDefault()?.Src ?? "")
                }).ToList()
            };

        }

        private async Task<BasketDto> CreateBasketForUser(string buyerId)
        {
            var newbasket = new Basket(buyerId);
            await db.Baskets.AddAsync(newbasket);
            var result = await db.SaveChangesAsync(true);

            if (result > 1)
            {
                return new BasketDto
                {
                    Id = newbasket.Id,
                    BuyerId = newbasket.BuyerId
                };
            }
            else return null;
            
        }
    }

    public class BasketDto
    {
        public int Id { get; set; }

        public string BuyerId { get; set; }

        public List<BasketItemDto> BasketItems { get; set; }

        public int TotalPrice { get; set; }


    }

    public class BasketItemDto
    {
        public int Id { get; set; }

        public int Price { get; set; }

        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public int Quantity { get; set; } = 1;

        public string? ImageUrl { get; set; }
    }
}
