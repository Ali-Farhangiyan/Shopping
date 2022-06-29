using Application.ImageServices.FacadeImage;
using Application.Interfaces;
using Application.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.PLPProduct
{
    public interface IPLPProductService
    {
        Task<PaginatedList<PLPProductDto>> ExecuteAsync(RequestPLPDto request);
    }

    public class PLPProductService : IPLPProductService
    {
        private readonly IDatabaseContext db;
        private readonly IImageService imageService;

        public PLPProductService(IDatabaseContext db, IImageService imageService)
        {
            this.db = db;
            this.imageService = imageService;
        }


        public async Task<PaginatedList<PLPProductDto>> ExecuteAsync(RequestPLPDto request)
        {

            
             var query = db.Products
                .Include(p => p.Images)
                .Include(p => p.Category)
                .AsQueryable();

            if(request.SortType == SortType.Newest)
            {
                query = query.OrderByDescending(p => p.Id).AsQueryable();
            }

            if (request.SortType == SortType.MostExpensive)
            {
                query = query.OrderByDescending(p => p.Price).AsQueryable();
            }

            if (request.SortType == SortType.Cheapest)
            {
                query = query.OrderBy(p => p.Price).AsQueryable();
            }

            if (!string.IsNullOrEmpty(request.SearchKey))
            {
                query = query.Where(p => p.Name.Contains(request.SearchKey));
            }

            if (!string.IsNullOrEmpty(request.CategorySlug))
            {
                var category = await db.Categories.FirstOrDefaultAsync(c => c.Slug == request.CategorySlug);
                query = query.Where(p => p.CategoryId == category.Id).AsQueryable();
            }

            var Brand = request.BrandId;

            if(request.BrandId != null)
            {
                query = query.Where(p => request.BrandId.Contains(p.BrandId)).AsQueryable();
            }



            var products = query.Select(p => new PLPProductDto
                {
                    Id = p.Id,
                    Slug = p.Slug,
                    Price = p.Price,
                    ProductName = p.Name,
                    ImageUrl = imageService.ImageComposer.Execute(p.Images.Where(i => i.ProductId == p.Id).FirstOrDefault().Src)
                }).AsQueryable();

            return await PaginatedList<PLPProductDto>.CreateAsync(products, request.PageSize, request.PageIndex);
        }
    }

    public class RequestPLPDto
    {
        public int PageSize { get; set; } = 2;
        public int PageIndex { get; set; } = 1;

        public string CategorySlug { get; set; }

        public string? SearchKey { get; set; }

        public int[]? BrandId { get; set; }

        public SortType SortType { get; set; }

    }

    public enum SortType
    {
        Cheapest = 1,
        MostExpensive=2,
        Newest=3,
        MostVisited=4
    }
    public class PLPProductDto
    {
        public int Id { get; set; }

        public string Slug { get; set; }
        public string ProductName { get; set; }

        public string ImageUrl { get; set; }

        public int Price { get; set; }

        public double Rate { get; set; }
    }
}
