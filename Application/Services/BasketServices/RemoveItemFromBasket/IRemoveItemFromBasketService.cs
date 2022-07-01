using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.BasketServices.RemoveItemFromBasket
{
    public interface IRemoveItemFromBasketService
    {
        Task<bool> ExecuteAsync(int productId);
    }

    public class RemoveItemFromBasketService : IRemoveItemFromBasketService
    {
        private readonly IDatabaseContext db;

        public RemoveItemFromBasketService(IDatabaseContext db)
        {
            this.db = db;
        }


        public async Task<bool> ExecuteAsync(int productId)
        {
            var basketItem = await db.BasketItems.FirstOrDefaultAsync(bi => bi.ProductId == productId);

            db.BasketItems.Remove(basketItem);
            var result = await db.SaveChangesAsync(true);

            if(result > 0)
            {
                return true;
            }
            return false;

        }
    }
}
