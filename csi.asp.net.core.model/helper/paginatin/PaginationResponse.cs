using csi.asp.net.core.model.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csi.asp.net.core.model.helper.paginatin
{
    public class PaginationResponse<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; set; }
        public bool PreviousPage { get; set; }
        public bool NextPage { get; set; }
        public List<T> result { get; set; }

        public PaginationResponse(Pagination<T> data)
        {
           
            this.PageIndex = data.PageIndex;
            this.TotalPages = data.TotalPages;

            this.PreviousPage = data.PreviousPage;
            this.NextPage = data.NextPage;

            this.result = data;
        }


    }
}
