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
    public class SiteController : ControllerBase
    {
        private readonly ISiteInterface _siteInterface;

        public SiteController(ISiteInterface siteInterface)
        {
            _siteInterface = siteInterface;
        }

        [HttpPost]
        public async Task<Site> Create(Site model)
        {
            try
            {
                return await _siteInterface.Create(model);

            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<Site> Update(Site model)
        {
            try
            {
                return await _siteInterface.Update(model);

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
                return Ok(_siteInterface.Pagination(PageNumber));
            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<Site> ReadById(int id)
        {
            try
            {
                return await _siteInterface.Read(id);

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
                await _siteInterface.Delete(id);

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
