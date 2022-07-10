using Application.Interfaces;
using Application.Services.CommentServices.AcceptComment;
using Application.Services.CommentServices.AddNewComment;
using Application.Services.CommentServices.GetAllComments;
using Application.Services.CommentServices.GetComment;
using Application.Services.CustomerServices.AddNewAddress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CommentServices.CommentFacade
{
    public interface ICommentService
    {
        IAddNewCommentService AddComment { get; }

        IGetAllCommentsService GetComments { get; }

        IAcceptCommentService AcceptComment { get; }

        IGetCommentService GetComment { get; }
    }

    public class CommentService : ICommentService
    {
        private readonly IDatabaseContext db;
        private readonly IIdentityDatabaseContext identityDb;

        public CommentService(IDatabaseContext db, IIdentityDatabaseContext identityDb)
        {
            this.db = db;
            this.identityDb = identityDb;
        }



        private IAddNewCommentService addComment;
        public IAddNewCommentService AddComment =>
            addComment ?? new AddNewCommentService(db);



        private IGetAllCommentsService getComments;
        public IGetAllCommentsService GetComments =>
            getComments ?? new GetAllCommentsService(db, identityDb);



        private IAcceptCommentService acceptComment;
        public IAcceptCommentService AcceptComment =>
            acceptComment ?? new AcceptCommentService(db);



        private IGetCommentService getComment;
        public IGetCommentService GetComment =>
            getComment ?? new GetCommentService(db, identityDb);
    }
}
