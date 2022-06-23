namespace Domain.Entites.Products
{
    public class Tags
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<Product>? Products { get; set; }
    }
}
