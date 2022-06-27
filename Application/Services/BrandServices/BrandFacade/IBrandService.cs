using Application.Interfaces;
using Application.Services.BrandServices.AddNewBrand;
using Application.Services.BrandServices.GetBrands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.BrandServices.BrandFacade
{
    public interface IBrandService
    {
        IAddNewBrandService AddNewBrands { get; }

        IGetBrandsService GetAllBrand { get; }
    }

    public class BrandService : IBrandService
    {
        private readonly IDatabaseContext db;

        public BrandService(IDatabaseContext db)
        {
            this.db = db;
        }




        private IAddNewBrandService addNewBrands;
        public IAddNewBrandService AddNewBrands =>
            addNewBrands ?? new AddNewBrandService(db);



        private IGetBrandsService getAllBrand;
        public IGetBrandsService GetAllBrand =>
            getAllBrand ?? new GetBrandsService(db);
    }
}
