using Domain.Entites.Attributes;

namespace Domain.Entites.Products
{
    [AuditTable]
    public class Image
    {
        public int Id { get; set; }

        public string? Src { get; set; }

        public Product? Product { get; set; }

        public int ProductId { get; set; }
    }
}
