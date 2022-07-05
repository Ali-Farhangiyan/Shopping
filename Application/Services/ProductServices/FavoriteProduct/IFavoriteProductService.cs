using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Domain.Entites.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.FavoriteProduct
{
    public interface IFavoriteProductService
    {
        Task AddToFavoriteAsync(string userId, int productId);
        Task RemoveFromFavoriteAsync(string userId, int productId);
    }

    public class FavoriteProductService : IFavoriteProductService
    {
        private readonly IDatabaseContext db;

        public FavoriteProductService(IDatabaseContext db)
        {
            this.db = db;
        }


        public async Task AddToFavoriteAsync(string userId, int productId)
        {
            var favorite = await db.Favorites
                .Include(f => f.Products)
                .FirstOrDefaultAsync(f => f.UserId == userId);

            if(favorite is null)
            {
                favorite = new Favorite
                {
                    UserId = userId,
                    Products = new List<Product>(),
                };
                await db.Favorites.AddAsync(favorite);

            }

            var product = await db.Products
                .FirstOrDefaultAsync(p => p.Id == productId);

            product.FavoriteCount += 1;

            favorite.Products.Add(product);


            await db.SaveChangesAsync(true);

        }

        public async Task RemoveFromFavoriteAsync(string userId, int productId)
        {
            var favorite = await db.Favorites
                .Include(p => p.Products)
                .FirstOrDefaultAsync(f => f.UserId == userId);


            var product = await db.Products
                .FirstOrDefaultAsync(p => p.Id == productId);

            product.FavoriteCount -= 1;

            favorite.Products.Remove(product);

            await db.SaveChangesAsync(true);
        }
    }
}
