using Application.Interfaces;
using Application.Services.CategoryServices.AddNewCategory;
using Application.Services.CategoryServices.DeleteCategory;
using Application.Services.CategoryServices.EditCategory;
using Application.Services.CategoryServices.GetCategories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CategoryServices.FacadeCategory
{
    public interface ICategoryService
    {
        public IAddNewCategoryService AddNewCategory { get; }
        public IEditCategoryService EditCategory { get; }
        public IGetCategories GetAllCategories { get; }
        public IDeleteCategoryService DeleteCategory { get; }
    }

    public class CategoryService : ICategoryService
    {
        private readonly IDatabaseContext db;
        private readonly IMapper mapper;

        public CategoryService(IDatabaseContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }


        private IAddNewCategoryService addNewCategoryService;
        public IAddNewCategoryService AddNewCategory =>
            addNewCategoryService ?? new AddNewCategoryService(db, mapper);


        private IEditCategoryService editCategoryService;
        public IEditCategoryService EditCategory =>
            editCategoryService ?? new EditCategoryService(db, mapper);


        private IGetCategories getCategories;

        public IGetCategories GetAllCategories =>
            getCategories ?? new GetCategories.GetCategories(db, mapper);


        private IDeleteCategoryService deleteCategoryService;
        public IDeleteCategoryService DeleteCategory => 
            deleteCategoryService ?? new DeleteCategoryService(db, mapper);

    }
}
