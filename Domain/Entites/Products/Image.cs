namespace Domain.Entites.Products
{
    public class Image
    {
        public int Id { get; set; }

        public string? Src { get; set; }

        public Product? Product { get; set; }

        public int ProductId { get; set; }
    }
}
