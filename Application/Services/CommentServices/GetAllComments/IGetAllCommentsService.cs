using Application.Interfaces;
using Application.Pagination;
using Domain.Entites.Comments;
using Domain.Entites.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CommentServices.GetAllComments
{
    public interface IGetAllCommentsService
    {
        Task<PaginatedList<GetCommentDto>> ExecuteAsync(RequestCommentDto request);
    }

    public class GetAllCommentsService : IGetAllCommentsService
    {
        private readonly IDatabaseContext db;
        private readonly IIdentityDatabaseContext identityDb;

        public GetAllCommentsService(IDatabaseContext db, IIdentityDatabaseContext identityDb)
        {
            this.db = db;
            this.identityDb = identityDb;
        }


        public async Task<PaginatedList<GetCommentDto>> ExecuteAsync(RequestCommentDto request)
        {
            var query =  db.Comments
                .Include(p => p.Product)
                .Include(p => p.ParentComment)
                .Include(p => p.ReplyComments)
                .OrderBy(p => p.Time)
                .AsQueryable();


            if (request.StatusOfCommentDto == StatusOfCommentDto.All)
            {
                query = query.Where(p => p.StatusOfComment == StatusOfComment.Waiting ||
                    p.StatusOfComment == StatusOfComment.Accepted ||
                    p.StatusOfComment == StatusOfComment.Rejected);
            }

            if (request.StatusOfCommentDto == StatusOfCommentDto.Waiting)
            {
                query = query.Where(p => p.StatusOfComment == StatusOfComment.Waiting);
            }

            if (request.StatusOfCommentDto == StatusOfCommentDto.Accepted)
            {
                query = query.Where(p => p.StatusOfComment == StatusOfComment.Accepted);
            }

            if (request.StatusOfCommentDto == StatusOfCommentDto.Rejected)
            {
                query = query.Where(p => p.StatusOfComment == StatusOfComment.Rejected);
            }

            if (request.Timing == Timing.Newest)
            {
                query = query.OrderBy(p => p.Id).AsQueryable();
            }

            if (request.Timing == Timing.Oldest)
            {
                query = query.OrderByDescending(p => p.Id).AsQueryable();
            }

            //var ids = query.Select(c => c.UserId).ToList();
            var emails = await identityDb.Users.Select(u =>new GetEmailDto
            {
                Id = u.Id,
                Email = u.Email
            }).ToListAsync();


            


            var data =  query.Select(c => new GetCommentDto
            {
                Email = c.UserId.ToString() ,
                Id = c.Id,
                NameProduct = db.Products.Where(p => p.Id == c.ProductId).FirstOrDefault().Name,
                Status = c.StatusOfComment

            });





            return await PaginatedList<GetCommentDto>.CreateAsync(data, request.PageSize, request.PageIndex);



        }
    }
    public class GetEmailDto
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
    }
    public class GetCommentDto
    {
        public int Id { get; set; }

        public string? Email { get; set; }

        public string? NameProduct { get; set; }

        public StatusOfComment Status { get; set; }


    }

    public class RequestCommentDto
    {
        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public StatusOfCommentDto StatusOfCommentDto { get; set; }

        public Timing Timing { get; set; }
    }

    public enum Timing
    {
        Newest=0,
        Oldest=1
    }

    public enum StatusOfCommentDto
    {
        
        Waiting = 0,
        Accepted = 1,
        Rejected = 2,
        All = 4
       
    }
}
