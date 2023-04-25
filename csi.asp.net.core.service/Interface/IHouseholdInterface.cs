
using csi.asp.net.core.model.dto_s;
using csi.asp.net.core.model.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csi.asp.net.core.service.Interface
{
    public interface IHouseholdInterface : ICommon<Household>
    {
        public Task<List<DropDown>> ReadFamilyHead();
        public Task<List<DropDown>> ReadFamilyOriginRef();

        public Task<List<DropDown>> ReadPartners();

    }
}
