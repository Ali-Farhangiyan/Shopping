using Application.ImageServices.FacadeImage;
using Application.Interfaces;
using Domain.Entites.Comments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.PDPProduct
{
    public interface IPDPProductService
    {
        Task<PDPProductDto> ExecuteAsync(string? Slug, string? userId);
    }

    public class PDPProductService : IPDPProductService
    {
        private readonly IDatabaseContext db;
        private readonly IImageService imageService;

        public PDPProductService(IDatabaseContext db, IImageService imageService)
        {
            this.db = db;
            this.imageService = imageService;
        }


        public async Task<PDPProductDto> ExecuteAsync(string? Slug,string? userId)
        {
            var product = await db.Products.FirstOrDefaultAsync(p => p.Slug == Slug);
            if (product is null) return null!;
            var isfav = false;
            if(userId is not null)
            {
                isfav = db.Favorites
                    .Include(p => p.Products)
                    .Where(p => p.UserId == userId)
                    .FirstOrDefault().Products.Any(p => p.Id == product.Id);
            }

            var images = await db.Images
                .Include(i => i.Product)
                .Where(i => i.ProductId == product.Id)
                .Select(i => new ImagePDPDto
                {
                    ImageUrl = imageService.ImageComposer.Execute(i.Src ?? "")
                })
                .ToListAsync();


            var comments = await db.Comments
                .Include(c => c.Product)
                .Where(c => c.ProductId == product.Id)
                .Select(c => new CommentPDPDto
                {
                    Id = c.Id,
                    Body = c.Body,
                    Email = c.UserId,
                    StatusOfComment = c.StatusOfComment
                })
                .Where(c => c.StatusOfComment == StatusOfComment.Accepted)
                .ToListAsync();


            var categories = new ListOfCategory
            {
                MainCategory = db.Categories
                .Where(c => c.Id == product.CategoryId)?
                .FirstOrDefault()?.Slug ?? "",
            };


            var productDto = new PDPProductDto
            {
                Id = product.Id,
                Slug = product.Slug,
                Name = product.Name,
                Price = product.Price,
                MetaTitle = product?.MetaTitle ?? "",
                Comments = comments,
                MetaDescription = product?.MetaDescription ?? "",
                Description = product?.Description ?? "",
                Images = images,
                IsFavorite = (isfav) ? true : false

            };

            return productDto;


        }
    }

    public class PDPProductDto
    {
        public int Id { get; set; }

        public string Slug { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public string Description { get; set; }

        public bool IsFavorite { get; set; } 

        public List<CommentPDPDto> Comments { get; set; }
        public ICollection<IGrouping<FeaturePDPDto,string>> Features { get; set; }
        public List<ImagePDPDto> Images { get; set; }
        public ListOfCategory ListOfCategories { get; set; }


    }

    public class CommentPDPDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Body { get; set; }

        public StatusOfComment StatusOfComment { get; set; }
    }



    public class FeaturePDPDto
    {
        public string Group { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }

    public class ImagePDPDto
    {
        public string ImageUrl { get; set; }
    }

    public class ListOfCategory
    {
        public string MainCategory { get; set; }

        public string ParentCategory { get; set; }

        public string GrandParentCategory { get; set; }
    }
}
