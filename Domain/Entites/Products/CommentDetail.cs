namespace Domain.Entites.Products
{
    public class CommentDetail
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public int Score { get; set; }

        public string? Body { get; set; }

        public int NumberOfLike { get; set; }

        public string? UserId { get; set; }

        public Comment? Comment { get; set; }

        public int CommentId { get; set; }
    }
}
