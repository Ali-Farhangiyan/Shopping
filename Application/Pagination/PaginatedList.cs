using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pagination
{
    public class PaginatedList<T> : List<T>
    {
        public int TotalPage { get; set; }

        public int PageIndex { get; set; }

        public bool HasNextPage => PageIndex < TotalPage;
        public bool HasPrevPage => PageIndex > 1;

        public PaginatedList(List<T> items,int Count, int PageSize, int PageIndex)
        {
            this.PageIndex = PageIndex;
            TotalPage = (int)Math.Ceiling(Count / (double)PageSize);

            this.AddRange(items);
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> model,int pageSize, int pageIndex)
        {
            int count = await model.CountAsync();
            var takeModel = await model.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(takeModel,count, pageSize, pageIndex);
        }
    }
}
