using Application.Interfaces;
using Application.Services.TagsServices.AddTag;
using Application.Services.TagsServices.GetTags;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TagsServices.TagFacade
{
    public interface ITagService
    {
        IAddTagService AddTag { get; }

        IGetTagService GetTag { get; }
    }

    public class TagService : ITagService
    {
        private readonly IDatabaseContext db;
        public TagService(IDatabaseContext db)
        {
            this.db = db;
        }


        private IAddTagService addTag;
        public IAddTagService AddTag => addTag ?? new AddTagService(db);

        private IGetTagService getTag;
        public IGetTagService GetTag => getTag ?? new GetTagService(db);
    }
}
