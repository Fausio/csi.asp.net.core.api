  
using csi.asp.net.core.model.helper;
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
    public class HouseholdController : ControllerBase
    {
        private readonly IHouseholdInterface _householdInterface; 

        public HouseholdController(IHouseholdInterface householdInterface)
        {
            _householdInterface = householdInterface;
        }

        [HttpPost]
        public async Task<Household> Create(Household model)
        {
            try
            {
                return await _householdInterface.Create(model);

            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<Household> Update(Household model)
        {
            try
            {
                return await _householdInterface.Update(model);

            }
            catch (Exception e)
            {

                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> Read([FromQuery] PaginationFilter filter)
        {
            try
            {
                var data = await _householdInterface.Read();

                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                var pagedData = data.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                          .Take(validFilter.PageSize)
                                          .ToList();

                var totalRecords = data.Count();
                //  return await _householdInterface.Read();

                //  return Ok(new PagedResponse<List<Household>>(pagedData, validFilter.PageNumber, validFilter.PageSize,));

                return Ok(_householdInterface.Pagenation(new model.helper.paginatin.OwnerParameters()));
            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<Household> Read(int id)
        {
            try
            {
                return await _householdInterface.Read(id);

            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task ReadById(int id)
        {
            try
            {
                await _householdInterface.Delete(id);

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
