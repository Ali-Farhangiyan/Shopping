using Application.Interfaces;
using Domain.Entites.Comments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CommentServices.AddNewComment
{
    public interface IAddNewCommentService
    {
        Task<bool> ExecuteAsync(AddNewCommentDto comment, string userId);
    }

    public class AddNewCommentService : IAddNewCommentService
    {
        private readonly IDatabaseContext db;

        public AddNewCommentService(IDatabaseContext db)
        {
            this.db = db;
        }
        public async Task<bool> ExecuteAsync(AddNewCommentDto comment, string userId)
        {
            var newComment = new Comment(userId)
            {
                Body = comment.Body,
                ProductId = comment.ProductId
            };

            await db.Comments.AddAsync(newComment);
            var result = await db.SaveChangesAsync(true);

            if(result > 0)
            {
                return true;
            }

            return false;
        }
    }

    public class AddNewCommentDto
    {
        [Required]
        [MinLength(3)]
        public string Body { get; set; } = null!;

        public int ProductId { get; set; }

    }
}
