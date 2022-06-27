using Application.ImageServices.FacadeImage;
using Application.Interfaces;
using Application.Services.GetBrandsProduct;
using Application.Services.ProductServices.AddNewProduct;
using Application.Services.ProductServices.GetCategoriesProduct;
using Application.Services.ProductServices.GetTagsProduct;
using Application.Services.ProductServices.ShowProducts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.ProductFacade
{
    public interface IProductService
    {
        IAddNewProudctService AddProduct { get; }
        IGetCategoriesProductService GetCategoriesProduct { get; }
        IGetTagsProductService GetTagsProduct { get; }
        IGetBrandsProductService GetBrandsProduct { get; }
        IShowProductsService ShowProducts { get; } 
    }

    public class ProductService : IProductService
    {

        public ProductService(IDatabaseContext db,
            IMapper mapper,
            IImageService imageService)
        {
            this.db = db;
            this.mapper = mapper;
            this.imageService = imageService;
        }
        
        private readonly IDatabaseContext db;
        private readonly IMapper mapper;
        private readonly IImageService imageService;
        private IAddNewProudctService addProduct;
        public IAddNewProudctService AddProduct =>
            addProduct ?? new AddNewProudctService(db,mapper);

        private IGetCategoriesProductService getCategoriesProduct;
        public IGetCategoriesProductService GetCategoriesProduct =>
            getCategoriesProduct ?? new GetCategoriesProductService(db);


        private IGetTagsProductService getTagsProduct;
        public IGetTagsProductService GetTagsProduct =>
            getTagsProduct ?? new GetTagsProductService(db);


        private IGetBrandsProductService getBrandsProduct;
        public IGetBrandsProductService GetBrandsProduct => 
            getBrandsProduct ?? new GetBrandsProductService(db);


        private IShowProductsService showProducts;
        public IShowProductsService ShowProducts =>
            showProducts ?? new ShowProudctsService(db,imageService);
    }
}
