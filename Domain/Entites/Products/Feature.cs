using Domain.Entites.Attributes;

namespace Domain.Entites.Products
{
    [AuditTable]
    public class Feature
    {
        public int Id { get; set; }

        public string? Group { get; set; }

        public string? Key { get; set; }

        public string? Value { get; set; }

        public Product? Product { get; set; }

        public int ProductId { get; set; }
    }
}
