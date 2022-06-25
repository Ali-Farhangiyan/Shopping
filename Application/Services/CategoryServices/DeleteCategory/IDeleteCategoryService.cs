using Application.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CategoryServices.DeleteCategory
{
    public interface IDeleteCategoryService
    {
        Task<bool> DeleteCategoryAsync(int Id);
    }

    public class DeleteCategoryService : IDeleteCategoryService
    {
        private readonly IDatabaseContext db;
        private readonly IMapper mapper;

        public DeleteCategoryService(IDatabaseContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<bool> DeleteCategoryAsync(int Id)
        {
            var category = await db.Categories.FindAsync(Id);
            if(category is null)
            {
                return false;
            }


            db.Categories.Remove(category);
            var result = await db.SaveChangesAsync(true);
            if(result > 0)
            {
                return true;
            }

            return false;
        }
    }
}
