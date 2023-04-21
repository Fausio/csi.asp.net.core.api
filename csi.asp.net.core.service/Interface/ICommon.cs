using csi.asp.net.core.model.helper.paginatin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csi.asp.net.core.service.Interface
{
    public interface ICommon<T>
    {
        public Task<T> Create(T entity);
        public Task<T> Update(T entity);
        public Task Delete(int id); 
        public Task<T> Read(int id); 
        public  PaginationResponse<T>  Pagination(int PageNumber);
       public  PaginationResponse<T> Search(string? Search);

    }
}
