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
    public class SiteService : ISiteInterface
    {
        public async Task<Site> Create(Site entity)
        {
            try
            {
                using var db = new CSI_AppContext();
                if (entity.Id == 0)
                {
                    await db.sites.AddAsync(entity);
                    await db.SaveChangesAsync();
                    return entity;
                }
                else
                {
                    throw new Exception("OCB ja existe na base de dados");
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
                    db.sites.Remove(data);
                    await db.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("OCB não existe na base de dados");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Site> Read(int id)
        {
            try
            {
                using var db = new CSI_AppContext();

                var data = await db.sites.FirstOrDefaultAsync(h => h.Id == id);
                if (data is not null)
                {
                    return data;
                }
                else
                {
                    throw new Exception("OCB não existe na base de dados");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public PaginationResponse<Site> Pagination(int PageNumber = 1)
        {
            try
            {
                using var db = new CSI_AppContext();
                var Pagination = Pagination<Site>.Create(db.sites.AsQueryable(), PageNumber, 10);
                var result = new PaginationResponse<Site>(Pagination);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Site> Update(Site entity)
        {
            try
            {
                using var db = new CSI_AppContext();

                if (entity.Id >= 0)
                {
                    db.sites.Update(entity);
                    await db.SaveChangesAsync();
                    return entity;
                }
                else
                {
                    throw new Exception("OCB não existe na base de dados");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
