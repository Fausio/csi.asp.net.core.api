using csi.asp.net.core.model.model;
using csi.asp.net.core.service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace csi.asp.net.core.api.Controllers
{

    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerInterface _partnerInterface  ;

        public PartnerController(IPartnerInterface partnerInterface)
        {
            _partnerInterface = partnerInterface;
        }


        [HttpPost]
        public async Task<Partner> Create(Partner model)
        {
            try
            {
                return await _partnerInterface.Create(model);

            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<Partner> Update(Partner model)
        {
            try
            {
                return await _partnerInterface.Update(model);

            }
            catch (Exception e)
            {

                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> Read([FromQuery] int PageNumber = 1)
        {
            try
            { 
                return Ok(_partnerInterface.Pagination(PageNumber));

            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<Partner> ReadById(int id)
        {
            try
            {
                return await _partnerInterface.Read(id);

            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            try
            {
                await _partnerInterface.Delete(id);

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
