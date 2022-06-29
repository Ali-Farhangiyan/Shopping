using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ShoppingUI.Models.ViewComponents
{
    public class Menu : ViewComponent
    {
        private readonly IDatabaseContext db;

        public Menu(IDatabaseContext db)
        {
            this.db = db;
        }
        public IViewComponentResult Invoke()
        {
            var categories = db.Categories
                .Include(c => c.ParentCategory)
                .Include(c => c.ParentCategory.ParentCategory)
                .ThenInclude(c => c.SubCategories)
                .Select(t => new MenuDto
                {
                    Id = t.Id,
                    CategorySlug = t.Slug,
                    ParentCategoryId = t.ParentCategoryId,
                    Name = t.Name
                }).ToList();
            return View("Menu",categories);
        }
    }

    public class MenuDto
    {
        public int Id { get; set; }

        public string CategorySlug { get; set; }

        public int? ParentCategoryId { get; set; }

        public string Name { get; set; }
    }
}
