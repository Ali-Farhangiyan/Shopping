using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.BasketServices.AddItemToBasket
{
    public interface IAddItemToBasketService
    {
        Task<bool> ExecutAsync(int basketId, int productId, int quantity);
    }

    public class AddItemToBasketService : IAddItemToBasketService
    {
        private readonly IDatabaseContext db;

        public AddItemToBasketService(IDatabaseContext db)
        {
            this.db = db;
        }
        public async Task<bool> ExecutAsync(int basketId, int productId, int quantity)
        {
            var basket = await db.Baskets
                .SingleOrDefaultAsync(b => b.Id == basketId);

            if(basket is null)
            {
                return false;
            }

            var product = await db.Products
                .FirstOrDefaultAsync(p => p.Id == productId);

            basket.AddItem(productId, quantity, product.Price);

            var result = await db.SaveChangesAsync(true);
            if(result > 0)
            {
                return true;
            }

            return false;
        }
    }
}
