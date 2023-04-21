using Newtonsoft.Json.Linq;
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

        public string[] ActiveOrCurrentPage { get; set; }

        public Pagination(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);

            if (TotalPages > 1)
            {
                this.EachTotalPages = Enumerable.Range(1, TotalPages).ToList();
            }
            else if (TotalPages == 1) 
            {
                this.EachTotalPages = new List<int> { 1 }; 
            }

            // active css code 
            if (EachTotalPages.Count() > 0)
            {
                var liTagClass = "page-item mr-2";
                int _pageIndex = (pageIndex - 1);

                this.ActiveOrCurrentPage = new string[EachTotalPages.Count()];
             

                //  var indexActive = Array.FindIndex(this.ActiveOrCurrentPage, row => row == ActiveClass);

                for (int i = 0; i < this.ActiveOrCurrentPage.Length; i++)
                { 
                    this.ActiveOrCurrentPage[i] = i == _pageIndex ? this.ActiveOrCurrentPage[i] = liTagClass+" active" : this.ActiveOrCurrentPage[i] = liTagClass; 
                }
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
