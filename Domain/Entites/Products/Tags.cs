using Domain.Entites.Attributes;

namespace Domain.Entites.Products
{
    [AuditTable]
    public class Tags
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<Product>? Products { get; set; }
    }
}
