using csi.asp.net.core.model.model;
using csi.asp.net.core.service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csi.asp.net.core.service.service
{
    public class SiteService : ISiteInterface
    {
        public Task<Site> Create(Site entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Site> Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Site>> Read()
        {
            throw new NotImplementedException();
        }

        public Task<Site> Update(Site entity)
        {
            throw new NotImplementedException();
        }
    }
}
