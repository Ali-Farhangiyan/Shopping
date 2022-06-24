

namespace Domain.Entites.Products
{
    public class Category
    {
        public int Id { get; set; }
        
        public string Slug { get; set; } = null!;

        public string Name { get; set; } = null!;

        public Category? ParentCategory { get; set; }
        public int? ParentCategoryId { get; set; }

        public ICollection<Category>? SubCategories { get; set; }

        public ICollection<Product>? Products { get; set; }

        
    }
}
