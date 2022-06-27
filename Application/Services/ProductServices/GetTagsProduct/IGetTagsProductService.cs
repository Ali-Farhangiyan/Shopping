using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.GetTagsProduct
{
    public interface IGetTagsProductService
    {
        Task<List<GetTagDto>> GetTagsAsync();
    }

    public class GetTagsProductService : IGetTagsProductService
    {
        private readonly IDatabaseContext db;

        public GetTagsProductService(IDatabaseContext db)
        {
            this.db = db;
        }


        public async Task<List<GetTagDto>> GetTagsAsync()
        {
            var tags = await db.Tags.Select(t => new GetTagDto
            {
                Id = t.Id,
                Name = t.Name
            }).ToListAsync();

            return tags;
        }
    }

    public class GetTagDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
