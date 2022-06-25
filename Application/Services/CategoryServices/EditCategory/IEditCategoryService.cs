using Application.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CategoryServices.EditCategory
{
    public interface IEditCategoryService
    {
        Task<bool> EditCategoryAsync(int Id, EditCategoryDto category);
    }

    public class EditCategoryService : IEditCategoryService
    {
        private readonly IDatabaseContext db;
        private readonly IMapper mapper;

        public EditCategoryService(IDatabaseContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<bool> EditCategoryAsync(int Id, EditCategoryDto category)
        {
            var oldCategory = await db.Categories.FindAsync(Id);

            var categoryUpdated = mapper.Map( category,oldCategory);
            if(categoryUpdated is null)
            {
                return false;
            }

            db.Categories.Update(categoryUpdated);

            var result = await db.SaveChangesAsync(true);
            if(result > 0)
            {
                return true;
            }

            return false;

        }
    }

    public class EditCategoryDto
    {
        public string? Name { get; set; }
        
        public string? Slug { get; set; }
    }

}
