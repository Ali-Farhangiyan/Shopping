using Application.Interfaces;
using Domain.Entites.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.BrandServices.AddNewBrand
{
    public interface IAddNewBrandService
    {
        Task<bool> AddBrandAsync(AddBrandDto brand);
    }

    public class AddNewBrandService : IAddNewBrandService
    {
        private readonly IDatabaseContext db;

        public AddNewBrandService(IDatabaseContext db)
        {
            this.db = db;
        }
        public async Task<bool> AddBrandAsync(AddBrandDto brand)
        {
            var newBrand = new Brand
            {
                Name = brand.Name
            };

            await db.Brands.AddAsync(newBrand);
            var result = await db.SaveChangesAsync(true);

            if(result > 0)
            {
                return true;
            }

            return false;
        }
    }

    public class AddBrandDto
    {
        public string Name { get; set; }
    }
}
