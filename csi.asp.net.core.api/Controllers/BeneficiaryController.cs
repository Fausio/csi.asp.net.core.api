using csi.asp.net.core.model.model;
using csi.asp.net.core.service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace csi.asp.net.core.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class BeneficiaryController : Controller
    {
        private readonly IBeneficiaryInterface _beneficiaryInterface ;
         
        public BeneficiaryController(IBeneficiaryInterface  beneficiaryInterface)
        {
            _beneficiaryInterface = beneficiaryInterface ;

        }

        [HttpPost]
        public async Task<Beneficiary> Create(Beneficiary model)
        {
            try
            {
                return await _beneficiaryInterface.Create(model); 
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<Beneficiary> Update(Beneficiary model)
        {
            try
            {
                return await _beneficiaryInterface.Update(model);

            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpGet("search")]

        public async Task<IActionResult> Search([FromQuery] string? search)
        {
            try
            {
                return Ok(_beneficiaryInterface.Search(search));
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
                return Ok(_beneficiaryInterface.Pagination(PageNumber));
            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<Beneficiary> ReadById(int id)
        {
            try
            {
                return await _beneficiaryInterface.Read(id);

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
                await _beneficiaryInterface.Delete(id);

            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
