using Application.Interfaces;
using Domain.Entites.Baskets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.BasketServices.TransferBasket
{
    public interface ITransferBasketService
    {
        Task ExecuteAsync(string anonymousId, string userId);
    }

    public class TransferBasketService : ITransferBasketService
    {
        private readonly IDatabaseContext db;

        public TransferBasketService(IDatabaseContext db)
        {
            this.db = db;
        }

        
        public async Task ExecuteAsync(string anonymousId, string userId)
        {
            var anonymousBasket = await db.Baskets
                .Include(b => b.BasketItems)
                .FirstOrDefaultAsync(b => b.BuyerId == anonymousId);

            if (anonymousBasket is null) return;
            var userBasket = await db.Baskets
                .Include(b => b.BasketItems)
                .FirstOrDefaultAsync(b => b.BuyerId == userId);

            if(userBasket is null)
            {
                userBasket = new Basket(userId);
                await db.Baskets.AddAsync(userBasket);

            }

            foreach (var item in anonymousBasket.BasketItems)
            {
                userBasket.AddItem(item.ProductId, item.Quantity, item.Price);
            }


            db.Baskets.Remove(anonymousBasket);
            await db.SaveChangesAsync(true);
        }
    }
}
