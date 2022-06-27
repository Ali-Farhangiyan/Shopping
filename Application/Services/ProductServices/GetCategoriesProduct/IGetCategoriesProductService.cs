using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.GetCategoriesProduct
{
    public interface IGetCategoriesProductService
    {
        List<GetCategorieProductDto> GetCategoriesProduct();
    }

    public class GetCategoriesProductService : IGetCategoriesProductService
    {
        private readonly IDatabaseContext db;

        public GetCategoriesProductService(IDatabaseContext db)
        {
            this.db = db;
        }

        public  List<GetCategorieProductDto> GetCategoriesProduct()
        {
            var categories = db.Categories
                .Include(p => p.ParentCategory)
                .ThenInclude(p => p.ParentCategory.ParentCategory)
                .Include(p => p.SubCategories)
                .Where(p => p.ParentCategoryId != null)
                .Where(p => p.SubCategories.Count == 0)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.ParentCategory,
                    p.SubCategories
                }).ToList()
                .Select(p => new GetCategorieProductDto
                {
                    Id = p.Id,
                    Name = $"{p?.ParentCategory?.ParentCategory?.Name ?? ""}" +
                        $" > {p?.ParentCategory?.Name ?? ""} > {p?.Name ?? ""}"
                }).ToList();

            return categories;
        }
    }

    public class GetCategorieProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
