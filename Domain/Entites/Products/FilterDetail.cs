namespace Domain.Entites.Products
{
    public class FilterDetail
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public Filter? Filter { get; set; }

        public int FilterId { get; set; }
    }
}
