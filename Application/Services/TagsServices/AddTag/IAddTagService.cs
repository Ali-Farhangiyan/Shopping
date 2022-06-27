using Application.Interfaces;
using Domain.Entites.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TagsServices.AddTag
{
    public interface IAddTagService
    {
        public Task<bool> AddTagAsync(AddTagDto tag);
    }

    public class AddTagService : IAddTagService
    {
        private readonly IDatabaseContext db;

        public AddTagService(IDatabaseContext db)
        {
            this.db = db;
        }
        public async Task<bool> AddTagAsync(AddTagDto tag)
        {
            var newTag = new Tags
            {
                Name = tag.Name
            };
            await db.Tags.AddAsync(newTag);
            var result = await db.SaveChangesAsync(true);

            if(result > 0)
            {
                return true;
            }

            return false;
        }
    }

    public class AddTagDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
    }
}
