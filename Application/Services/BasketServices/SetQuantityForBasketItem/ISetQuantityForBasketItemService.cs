using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.BasketServices.SetQuantityForBasketItem
{
    public interface ISetQuantityForBasketItemService
    {
        Task<bool> ExecuteAsync(int productId);
    }

    public class SetQuantityForBasketItemService : ISetQuantityForBasketItemService
    {
        private readonly IDatabaseContext db;

        public SetQuantityForBasketItemService(IDatabaseContext db)
        {
            this.db = db;
        }
        public async Task<bool> ExecuteAsync(int productId)
        {
            var basketitem = await db.BasketItems.FirstOrDefaultAsync(bi => bi.ProductId == productId);

            basketitem.AddQuantity();

            var result = await db.SaveChangesAsync(true);

            if(result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
