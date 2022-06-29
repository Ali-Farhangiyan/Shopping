using Application.ImageServices.FacadeImage;
using Application.Interfaces;
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
        Task<PDPProductDto> ExecuteAsync(string? Slug);
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


        public async Task<PDPProductDto> ExecuteAsync(string? Slug)
        {
            var product = await db.Products.FirstOrDefaultAsync(p => p.Slug == Slug);

            var images = await db.Images
                .Include(i => i.Product)
                .Where(i => i.ProductId == product.Id)
                .Select(i => new ImagePDPDto
                {
                    ImageUrl = imageService.ImageComposer.Execute(i.Src)
                })
                .ToListAsync();

            var comments = await db.Comments
                .Include(c => c.Product)
                .Where(c => c.ProductId == product.Id)
                .Select(c => new CommentPDPDto
                {
                    Id = c.Id,
                    Body = c.Body,
                    Email = c.Email,
                    Title = c.Title
                }).ToListAsync();


            var categories = new ListOfCategory
            {
                MainCategory = db.Categories.Where(c => c.Id == product.CategoryId).FirstOrDefault().Slug,
            };


            var productDto = new PDPProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                MetaTitle = product.MetaTitle,
                MetaDescription = product.MetaDescription,
                Description = product.Description,
                Comments = comments,
                Images = images,

            };

            return productDto;


        }
    }

    public class PDPProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public string Description { get; set; }


        public List<CommentPDPDto> Comments { get; set; }
        public ICollection<IGrouping<FeaturePDPDto,string>> Features { get; set; }
        public List<ImagePDPDto> Images { get; set; }
        public ListOfCategory ListOfCategories { get; set; }


    }

    public class CommentPDPDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
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
