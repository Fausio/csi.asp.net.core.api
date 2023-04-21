using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csi.asp.net.core.model.helper.paginatin
{
    public class Pagination<T> : List<T>
    {

        public int PageIndex { get; private set; }
        public int TotalPages { get; set; }
        public List<int> EachTotalPages { get; set; }


        public Pagination(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);

            if (TotalPages > 1)
            {
                    if (this.ActiveOrCurrentPage[pageIndex].IndexOf() != pageIndex )
                
              this.EachTotalPages =  Enumerable.Range(1, TotalPages).ToList();
                    if (this.this.ActiveOrCurrentPage[pageIndex] != )
            }
            
        }

        public bool PreviousPage { get { return (PageIndex > 1); } }

        public bool NextPage { get { return (PageIndex < TotalPages); } }

        public static Pagination<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
             
            return new Pagination<T>(items, count, pageIndex, pageSize);
        }

      
    }
}
