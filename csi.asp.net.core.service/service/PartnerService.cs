using csi.asp.net.core.model.model;
using csi.asp.net.core.service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csi.asp.net.core.service.service
{
    public class PartnerService : IPartnerInterface
    {
        public Task<Partner> Create(Partner entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Partner> Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Partner>> Read()
        {
            throw new NotImplementedException();
        }

        public Task<Partner> Update(Partner entity)
        {
            throw new NotImplementedException();
        }
    }
}
