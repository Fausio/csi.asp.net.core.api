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
    public class HouseholdService : IHouseholdInterface
    {
        public async Task<Household> Create(Household entity)
        {
            try
            {
                using var db = new CSI_AppContext();
                if (entity.Id == 0)
                {
                    await db.houseHolds.AddAsync(entity);
                    await db.SaveChangesAsync();
                    return entity;
                }
                else
                {
                    throw new Exception("Hagregado ja existe na base de dados");
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
                    db.houseHolds.Remove(data);
                    await db.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Hagregado não existe na base de dados");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Household> Read(int id)
        {
            try
            {
                using var db = new CSI_AppContext();

                var data = await db.houseHolds.FirstOrDefaultAsync(h => h.Id == id);
                if (data is not null)
                {
                    return data;
                }
                else
                {
                    throw new Exception("Hagregado não existe na base de dados");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Household>> Read()
        {
            try
            {
                using var db = new CSI_AppContext();
                return await db.houseHolds.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Household> Update(Household entity)
        {
            try
            {
                using var db = new CSI_AppContext();

                if (entity.Id >= 0)
                {
                    db.houseHolds.Update(entity);
                    await db.SaveChangesAsync();
                    return entity;
                }
                else
                {
                    throw new Exception("Hagregado não existe na base de dados");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
