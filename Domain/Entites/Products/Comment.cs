namespace Domain.Entites.Products
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public int Score { get; set; }

        public string? Body { get; set; }

        public int NumberOfLike { get; set; }

        public string? Email { get; set; }

        public Product? Product { get; set; }

        public int ProductId { get; set; }

        

    }

}
