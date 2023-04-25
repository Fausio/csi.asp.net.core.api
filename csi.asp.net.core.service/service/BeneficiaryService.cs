using csi.asp.net.core.data.App.Context;
using csi.asp.net.core.model.helper.paginatin;
using csi.asp.net.core.model.model;
using csi.asp.net.core.service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csi.asp.net.core.service.service
{
    public class BeneficiaryService : IBeneficiaryInterface
    {
        public async Task<Beneficiary> Create(Beneficiary entity)
        {
            try
            {
                using var db = new CSI_AppContext();
                if (entity.Id == 0)
                {

                    entity.CreatedDate = DateTime.Now;
                    entity.Guid = Guid.NewGuid();

                    await db.Beneficiarys.AddAsync(entity);
                    await db.SaveChangesAsync();
                    return entity;
                }
                else
                {
                    throw new Exception("beneficiario ja existe na base de dados");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                using var db = new CSI_AppContext();

                var data = await Read(id);

                if (data is not null)
                {
                    db.Beneficiarys.Remove(data);
                    await db.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("beneficiario não existe na base de dados");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    

        public PaginationResponse<Beneficiary> Pagination(int PageNumber = 1)
        {
            try
            {

                using var db = new CSI_AppContext();
                var Pagination = Pagination<Beneficiary>.Create(db.Beneficiarys.AsQueryable(), PageNumber, 10);
                var result = new PaginationResponse<Beneficiary>(Pagination);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Beneficiary> Read(int id)
        {
            try
            {
                using var db = new CSI_AppContext();

                var data = await db.Beneficiarys.FirstOrDefaultAsync(h => h.Id == id);
                if (data is not null)
                {
                    return data;
                }
                else
                {
                    throw new Exception("Beneficiario não existe na base de dados");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public PaginationResponse<Beneficiary> Search(string? SearchTxt)
        {
            try
            {
                if (string.IsNullOrEmpty(SearchTxt))
                {
                    return Pagination();
                }
                else
                {
                    using var db = new CSI_AppContext();
                    var query = db.Beneficiarys.Where(x => x.Name.Contains(SearchTxt) || x.Id.ToString().Contains(SearchTxt)).AsQueryable();

                    if (query.Count() <= 0)
                    {
                        return null;
                    }
                    else
                    {
                        var Pagination = Pagination<Beneficiary>.Create(query, 1, 20);
                        var result = new PaginationResponse<Beneficiary>(Pagination);
                        return result;
                    } 
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PaginationResponse<Beneficiary>> GetByHouseholdId(int householdId)
        {
            try
            {
                using var db = new CSI_AppContext();
                var query = db.Beneficiarys.Where(b => b.HouseholdId == householdId).OrderBy(b => b.Name).AsQueryable();

                var Pagination = Pagination<Beneficiary>.Create(query, 1, 20);
                var result = new PaginationResponse<Beneficiary>(Pagination);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Beneficiary> Update(Beneficiary entity)
        {
            try
            {
                using var db = new CSI_AppContext();

                if (entity.Id >= 0)
                {
                    entity.UpdatedDate = DateTime.Now;

                    db.Beneficiarys.Update(entity);
                    await db.SaveChangesAsync();
                    return entity;
                }
                else
                {
                    throw new Exception("beneficiario não existe na base de dados");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
