using Application.Interfaces;
using Application.Pagination;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CategoryServices.GetCategories
{
    public interface IGetCategories
    {
        Task<PaginatedList<CategoryDto>> GetCategoriesAsync(int? Id, int pageSize, int pageIndex);
    }

    public class GetCategories : IGetCategories
    {
        private readonly IDatabaseContext db;
        private readonly IMapper mapper;

        public GetCategories(IDatabaseContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<PaginatedList<CategoryDto>> GetCategoriesAsync(int? Id, int pageSize, int pageIndex)
        {
            var categories =  db.Categories
                .Where(c => c.ParentCategoryId == Id)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    ParentCategoryId = c.ParentCategoryId,
                    Slug = c.Slug,
                    SubCategories = c.SubCategories.Select(f => f.Id).ToList()
                }).AsQueryable();

            return await PaginatedList<CategoryDto>.CreateAsync(categories,pageSize,pageIndex);
        }
    }

    public class CategoryDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        
        public string? Slug { get; set; }

        public List<int>? SubCategories { get; set; }

        public int? ParentCategoryId { get; set; }
    }
}
