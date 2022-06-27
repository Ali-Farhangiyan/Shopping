using Application.Services.CategoryServices.AddNewCategory;
using Application.Services.CategoryServices.EditCategory;
using Application.Services.ProductServices.AddNewProduct;
using AutoMapper;
using Domain.Entites.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, AddCategoryDto>().ReverseMap();
            CreateMap<Category, EditCategoryDto>().ReverseMap();



            CreateMap<AddProductDto, Product>().ReverseMap();
            CreateMap<ImageDto, Image>().ReverseMap();
            CreateMap<TagsDto, Tags>().ReverseMap();
            CreateMap<FeatureDto, Feature>().ReverseMap();


        }
    }
}
