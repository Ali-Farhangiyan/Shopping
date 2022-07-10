using Application.Interfaces;
using Application.Services.CommentServices.GetAllComments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CommentServices.GetComment
{
    public interface IGetCommentService
    {
        Task<GetCommentDto> ExecuteAsync(int Id);
    }

    public class GetCommentService : IGetCommentService
    {
        private readonly IDatabaseContext db;
        private readonly IIdentityDatabaseContext identityDb;

        public GetCommentService(IDatabaseContext db, IIdentityDatabaseContext identityDb)
        {
            this.db = db;
            this.identityDb = identityDb;
        }


        public async Task<GetCommentDto> ExecuteAsync(int Id)
        {
            var comment = await db.Comments
                .Where(c => c.Id == Id)
                .Select(c => new GetCommentDto
                {
                    Email = c.UserId,
                    Id = c.Id,
                    NameProduct = db.Products.Where(p => p.Id == c.ProductId).FirstOrDefault().Name,
                    Status = c.StatusOfComment
                }).FirstOrDefaultAsync();

            return comment;


        }
    }
}
