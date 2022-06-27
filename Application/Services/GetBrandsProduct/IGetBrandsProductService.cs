using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.GetBrandsProduct
{
    public interface IGetBrandsProductService
    {
        List<BrandDto> GetBrandsProduct();
    }

    public class GetBrandsProductService : IGetBrandsProductService
    {
        private readonly IDatabaseContext db;

        public GetBrandsProductService(IDatabaseContext db)
        {
            this.db = db;
        }
        public List<BrandDto> GetBrandsProduct()
        {
            var brands = db.Brands
                .Select(b => new BrandDto
                {
                    Id = b.Id,
                    Name = b.Name
                }).ToList();

            return brands;
        }
    }

    public class BrandDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
