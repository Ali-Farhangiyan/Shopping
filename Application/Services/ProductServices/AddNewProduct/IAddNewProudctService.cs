using Application.Interfaces;
using AutoMapper;
using Domain.Entites.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.AddNewProduct
{
    public interface IAddNewProudctService
    {
        Task<bool> AddProductAsync(AddProductDto newProduct);
    }

    public class AddNewProudctService : IAddNewProudctService
    {
        private readonly IDatabaseContext db;
        private readonly IMapper mapper;

        public AddNewProudctService(IDatabaseContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }


        public async Task<bool> AddProductAsync(AddProductDto newProduct)
        {
            var product = mapper.Map<Product>(newProduct);

            await db.Products.AddAsync(product);
            var result = await db.SaveChangesAsync(true);
            if(result > 0)
            {
                return true;
            }
            return false;
        }
    }

    public class AddProductDto
    {
        [Required]
        [MaxLength(350)]
        public string Slug { get; set; } = null!;
        [Required]
        [MaxLength(250)]
        [Display(Name = "Product Name")]
        public string Name { get; set; } = null!;
        [Required]
        public int Price { get; set; }

        [Display(Name ="Description For Product Detail Page")]
        public string? MetaDescription { get; set; }

        [Display(Name = "Title For Product Detail Page")]
        public string? MetaTitle { get; set; }
        [Required]
        public string Description { get; set; } = null!;

        public int CategoryId { get; set; }

        public int BrandId { get; set; }

        public List<ImageDto>? Images { get; set; }

        public List<TagsDto>? Tags { get; set; }

        public List<FeatureDto> Features { get; set; }
    }

    public class ImageDto
    {
        public string? Src { get; set; }
    }

    public class TagsDto
    {

        public string Name { get; set; } = null!;

    }

    public class FeatureDto
    {

        public string? Group { get; set; }

        public string? Key { get; set; }

        public string? Value { get; set; }

    }
}
