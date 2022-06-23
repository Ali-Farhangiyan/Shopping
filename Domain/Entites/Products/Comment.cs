namespace Domain.Entites.Products
{
    public class Comment
    {
        public int Id { get; set; }

        public Product? Product { get; set; }

        public int ProductId { get; set; }

        public ICollection<CommentDetail>? CommentDetails { get; set; }

    }
}
