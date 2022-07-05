using Application.ImageServices.FacadeImage;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CustomerServices.GetInfo
{
    public interface IGetInfoService
    {
        Task<GetInfoDto> ExecuteAsync(string userId);
    }

    public class GetInfoService : IGetInfoService
    {
        private readonly IIdentityDatabaseContext identityDb;
        private readonly IDatabaseContext db;
        private readonly IImageService imageService;

        public GetInfoService( IIdentityDatabaseContext identityDb, IDatabaseContext db,IImageService imageService)
        {
            this.identityDb = identityDb;
            this.db = db;
            this.imageService = imageService;
        }


        public async Task<GetInfoDto> ExecuteAsync(string userId)
        {
            var user = await identityDb.Users.FindAsync(userId);

            var ids =  db.Favorites.Include(p => p.Products).Where(p => p.UserId == userId)?
                .FirstOrDefault()?.Products?.Select(p => p.Id).ToList();

            var products = await db.Products.Include(p => p.Images).Include(p => p.Favorites)
                .Where(p => ids.Contains(p.Id))
                .ToListAsync();
            
                

            var userShow = new GetInfoDto
            {
                Email = user?.Email ?? "",
                FirstName = user?.FullName?.Split(" ").FirstOrDefault() ?? "",
                LastName = user?.FullName?.Split(" ").LastOrDefault() ?? "",
                PhoneNumber = user?.PhoneNumber ?? "",
                Addresses = await db.Addresses.Where(p => p.UserId == userId).Select(p => new ShowAddressDto
                {
                    PostalCode = p.PostalCode,
                    WholeAddress = $"{p.State} - {p.City} - {p.Street} - {p.Allay} - {p.Plaque}"
                }).ToListAsync(),
                FavoriteItems =  products
                .Select(p => new FavoriteItem
                {
                    Id = p.Id,
                    Slug = p.Slug,
                    ImageUrl = imageService.ImageComposer.Execute(p?.Images?.FirstOrDefault()?.Src ?? ""),
                    Name = p.Name,
                    Price = p.Price
                }).ToList()

            };

            return userShow;
        }
    }

    public class GetInfoDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public List<ShowAddressDto> Addresses { get; set; }

        public List<FavoriteItem> FavoriteItems { get; set; }
    }

    public class ShowAddressDto
    {
        public string PostalCode { get; set; }

        public string WholeAddress { get; set; }
    }

    public class FavoriteItem
    {
        public int Id { get; set; }

        public string Slug { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string ImageUrl { get; set; }
    }
}
