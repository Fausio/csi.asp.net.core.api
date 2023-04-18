using csi.asp.net.core.data.App.Context;
using csi.asp.net.core.model.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csi.asp.net.core.data.Seed
{
    public static class SeedData
    {


        private static List<Site> SiteToSeed = new List<Site> { new Site() { Guid = Guid.NewGuid(), CreatedDate = DateTime.Now, Name = "OCB Principal" } };


        private static List<Partner> PartnerToSeed()
        {
            List<Partner> data = new List<Partner>();

            data.Add(new Partner() { Guid = Guid.NewGuid(), Name = "partner 1", CreatedDate = DateTime.Now, Site = SiteToSeed.FirstOrDefault(), CollaboratorRoleId = 1 });
            data.Add(new Partner() { Guid = Guid.NewGuid(), Name = "partner 2", CreatedDate = DateTime.Now, Site = SiteToSeed.FirstOrDefault(), CollaboratorRoleId = 1 });

            data.Add(new Partner() { Guid = Guid.NewGuid(), Name = "partner 3", CreatedDate = DateTime.Now, Site = SiteToSeed.FirstOrDefault(), CollaboratorRoleId = 2 });
            data.Add(new Partner() { Guid = Guid.NewGuid(), Name = "partner 4", CreatedDate = DateTime.Now, Site = SiteToSeed.FirstOrDefault(), CollaboratorRoleId = 2 });
            data.Add(new Partner() { Guid = Guid.NewGuid(), Name = "partner 5", CreatedDate = DateTime.Now, Site = SiteToSeed.FirstOrDefault(), CollaboratorRoleId = 2 });

            data.Add(new Partner() { Guid = Guid.NewGuid(), Name = "partner 6", CreatedDate = DateTime.Now, Site = SiteToSeed.FirstOrDefault(), CollaboratorRoleId = 3 });
            data.Add(new Partner() { Guid = Guid.NewGuid(), Name = "partner 7", CreatedDate = DateTime.Now, Site = SiteToSeed.FirstOrDefault(), CollaboratorRoleId = 3 });
            data.Add(new Partner() { Guid = Guid.NewGuid(), Name = "partner 8", CreatedDate = DateTime.Now, Site = SiteToSeed.FirstOrDefault(), CollaboratorRoleId = 3 });




            return data;

        }

        private static List<Household> HouseholdToSeed()
        {

            try
            {
                List<Household> data = new List<Household>();

                var x = PartnerToSeed;

                for (int i = 0; i < 30; i++)
                {
                    data.Add(new Household() { Address = $"Cidade {i}", Guid = Guid.NewGuid(), Name = $@"Household {i}", CreatedDate = DateTime.Now, });

                }

                return data;
            }
            catch (Exception e)
            {

                Console.WriteLine("Erro", e);
                throw;
            }

        }


        public static async Task Run()
        {
            using CSI_AppContext db = new CSI_AppContext();


            if (db.collaboratorRoles.Count() == 0)
            {
                var cb = new List<CollaboratorRole>()
                {
                    new CollaboratorRole(){ Description = "Supervisor" ,Guid = Guid.NewGuid(),CreatedDate =  DateTime.Now, },
                    new CollaboratorRole(){ Description = "chefe",Guid = Guid.NewGuid(),CreatedDate =  DateTime.Now, },
                    new CollaboratorRole(){ Description = "normal", Guid = Guid.NewGuid(),CreatedDate =  DateTime.Now, }
                };

                await db.collaboratorRoles.AddRangeAsync(cb);
                await db.SaveChangesAsync();
            }


            if (db.partners.Count() == 0)
            {

                var data = PartnerToSeed();
                await db.partners.AddRangeAsync(data);
                await db.SaveChangesAsync();


                data.ForEach(x =>
                {

                    if (new List<string>() { "partner 3", "partner 4", "partner 5" }.Contains(x.Name))
                    {
                        x.Superior = data.Where(p => p.Name == "partner 1").FirstOrDefault();
                    }

                    if (new List<string>() { "partner 6", "partner 7", "partner 8" }.Contains(x.Name))
                    {
                        x.Superior = data.Where(p => p.Name == "partner 5").FirstOrDefault();
                    }
                });


                db.partners.UpdateRange(data);

            }


            if (db.houseHolds.Count() == 0)
            {
                var data = HouseholdToSeed();

                data.ForEach(x =>
                {
                    int rondomPartner = new Random().Next(6, 8); // normal parner id range  
                    x.PartnerId = db.partners.FirstOrDefault(p => p.Id == rondomPartner).Id;

                });


                db.houseHolds.AddRange(data);
                await db.SaveChangesAsync();
            }
        }

    }


}
