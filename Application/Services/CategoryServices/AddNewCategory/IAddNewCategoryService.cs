using Application.Interfaces;
using AutoMapper;
using Domain.Entites.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CategoryServices.AddNewCategory
{
    public interface IAddNewCategoryService
    {
        Task<bool> AddCategoryAsync(AddCategoryDto newCategory);
    }

    public class AddNewCategoryService : IAddNewCategoryService
    {
        private readonly IDatabaseContext db;
        private readonly IMapper mapper;

        public AddNewCategoryService(IDatabaseContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }


        public async Task<bool> AddCategoryAsync(AddCategoryDto newCategory)
        {
            Category category = mapper.Map<Category>(newCategory);

            await db.Categories.AddAsync(category);
            var result = await db.SaveChangesAsync(true);

            if(result > 0)
            {
                return true;
            }

            return false;
        }
    }

    public class AddCategoryDto
    {

        
        [Required]
        [MaxLength(250)]
        [Display(Name = "Category Name")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(250)]
        [Display(Name = "Slug For Category")]
        public string Slug { get; set; } = null!;

        public int? ParentCategoryId { get; set; }


    }
}
