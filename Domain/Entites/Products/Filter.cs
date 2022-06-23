namespace Domain.Entites.Products
{
    public class Filter
    {
        public int Id { get; set; }

        public Category? Category { get; set; }

        public int CategoryId { get; set; }

        public ICollection<FilterDetail>? FilterDetails { get; set; }

    }
}
