using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.BrandServices.GetBrands
{
    public interface IGetBrandsService
    {
        Task<List<GetBrandDto>> GetAllBrandsAsync();
    }

    public class GetBrandsService : IGetBrandsService
    {
        private readonly IDatabaseContext db;

        public GetBrandsService(IDatabaseContext db)
        {
            this.db = db;
        }
        public async Task<List<GetBrandDto>> GetAllBrandsAsync()
        {
            var brands =await db.Brands
                .Select(b => new GetBrandDto
                {
                    Id = b.Id,
                    Name = b.Name
                }).ToListAsync();

            return brands;
        }
    }

    public class GetBrandDto
    {
        public int Id { get; set; }
        

        public string Name { get; set; }
    }
}
