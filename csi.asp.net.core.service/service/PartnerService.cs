using csi.asp.net.core.data.App.Context;
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
    public class PartnerService :IPartnerInterface
    {
        public async Task<Partner> Create(Partner entity)
        {
            try
            {
                using var db = new CSI_AppContext();
                if (entity.Id == 0)
                {
                    await db.partners.AddAsync(entity);
                    await db.SaveChangesAsync();
                    return entity;
                }
                else
                {
                    throw new Exception("Ativista ja existe na base de dados");
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
                    db.partners.Remove(data);
                    await db.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Ativista não existe na base de dados");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Partner> Read(int id)
        {
            try
            {
                using var db = new CSI_AppContext();

                var data = await db.partners.FirstOrDefaultAsync(h => h.Id == id);
                if (data is not null)
                {
                    return data;
                }
                else
                {
                    throw new Exception("Ativista não existe na base de dados");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Partner>> Read()
        {
            try
            {
                using var db = new CSI_AppContext();
                return await db.partners.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Partner> Update(Partner entity)
        {
            try
            {
                using var db = new CSI_AppContext();

                if (entity.Id >= 0)
                {
                    db.partners.Update(entity);
                    await db.SaveChangesAsync();
                    return entity;
                }
                else
                {
                    throw new Exception("Ativista não existe na base de dados");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
