using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CommentServices.AcceptComment
{
    public interface IAcceptCommentService
    {
        Task ExecuteAsync(AcceptCommentDto acceptComment);
    }

    public class AcceptCommentService : IAcceptCommentService
    {
        private readonly IDatabaseContext db;

        public AcceptCommentService(IDatabaseContext db)
        {
            this.db = db;
        }
        public async Task ExecuteAsync(AcceptCommentDto acceptComment)
        {
            var comment = await db.Comments.FindAsync(acceptComment.CommentId);

            

            if(acceptComment.StatusAccept == StatusAccept.Accepted)
            {
                comment.StatusOfComment = Domain.Entites.Comments.StatusOfComment.Accepted;
            }

            if (acceptComment.StatusAccept == StatusAccept.Waiting)
            {
                comment.StatusOfComment = Domain.Entites.Comments.StatusOfComment.Waiting;
            }

            if (acceptComment.StatusAccept == StatusAccept.Rejected)
            {
                comment.StatusOfComment = Domain.Entites.Comments.StatusOfComment.Rejected;
            }

            await db.SaveChangesAsync(true);
        }
    }



    public class AcceptCommentDto
    {
        public int CommentId { get; set; }
        public StatusAccept StatusAccept { get; set; }
    }

    public enum StatusAccept
    {
        Waiting = 0,
        Accepted = 1,
        Rejected = 2
    }

}
