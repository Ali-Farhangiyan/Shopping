using Domain.Entites.Attributes;

namespace Domain.Entites.Products
{
    [AuditTable]
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
