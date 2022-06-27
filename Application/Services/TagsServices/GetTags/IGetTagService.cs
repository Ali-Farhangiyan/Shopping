using Application.Interfaces;
using Application.Pagination;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TagsServices.GetTags
{
    public interface IGetTagService
    {
        Task<PaginatedList<TagDto>> GetTagsAsync(int pageSize, int PageIndex);
    }

    public class GetTagService : IGetTagService
    {
        private readonly IDatabaseContext db;

        public GetTagService(IDatabaseContext db)
        {
            this.db = db;
        }
        public async Task<PaginatedList<TagDto>> GetTagsAsync(int pageSize, int PageIndex)
        {
            var tags = db.Tags
                .Include(t => t.Products)
                .Select(t => new TagDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    IdOfProducts = t.Products.Select(t => t.Id).ToList()
                }).AsQueryable();

            return await PaginatedList<TagDto>.CreateAsync(tags, pageSize, PageIndex);

        }
    }

    public class TagDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<int> IdOfProducts { get; set; }
    }
}
