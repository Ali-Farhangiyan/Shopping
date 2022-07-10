using Domain.Entites.Attributes;
using Domain.Entites.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.Comments
{
    [AuditTable]
    public class Comment
    {
        public int Id { get; set; }

        public string UserId { get; private set; } = null!;

        public DateTime Time { get; set; } = DateTime.Now;

        public int NumberOfLikes { get; set; } = 0;

        public int NumberOfDislikes { get; set; } = 0;

        public StatusOfComment StatusOfComment { get; set; } = StatusOfComment.Waiting;

        public string Body { get; set; } = null!;

        public Product? Product { get; set; }

        public int ProductId { get; set; }

        public Comment? ParentComment { get; set; }

        public int? ParentCommentId { get; set; }

        public ICollection<Comment>? ReplyComments { get; set; }

        public Comment(string userId)
        {
            UserId = userId;
        }
    }

    public enum StatusOfComment
    {
        Waiting = 0,
        Accepted = 1,
        Rejected = 2
    }
}
