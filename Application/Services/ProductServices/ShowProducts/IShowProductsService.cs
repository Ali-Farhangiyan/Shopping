using Application.ImageServices.FacadeImage;
using Application.Interfaces;
using Application.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.ShowProducts
{
    public interface IShowProductsService
    {
        Task<PaginatedList<ShowProductDto>> ShowProductsAsync(int pageSize, int pageIndex);
    }

    public class ShowProudctsService : IShowProductsService
    {
        private readonly IDatabaseContext db;
        private readonly IImageService imageService;

        public ShowProudctsService(IDatabaseContext db, IImageService imageService)
        {
            this.db = db;
            this.imageService = imageService;
        }


        public async Task<PaginatedList<ShowProductDto>> ShowProductsAsync(int pageSize, int pageIndex)
        {
            var products =  db.Products.
                Include(p => p.Category)
                .Include(p => p.Images)
                .Include(p => p.Brand)
                .Include(p => p.Tags)
                .Include(p => p.Features)
                .Select(p => new ShowProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    CategoryName = p.Category.Name,
                    BrandName = p.Brand.Name,
                    ImageUrl = imageService.ImageComposer.Execute( p.Images.Where(i => i.ProductId == p.Id).FirstOrDefault().Src )
                }).AsQueryable();

            return await PaginatedList<ShowProductDto>.CreateAsync(products, pageSize, pageIndex);
        }
    }

    public class ShowProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public string CategoryName { get; set; }

        public string BrandName { get; set; }

        public string ImageUrl { get; set; }


    }
}
