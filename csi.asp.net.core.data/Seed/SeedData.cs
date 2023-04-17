using csi.asp.net.core.model.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csi.asp.net.core.data.Seed
{
    public class SeedData
    {


        private static List<Site> SiteToSeed = new List<Site> { new Site() { CreatedDate = new DateTime(), Name = "OCB Principal" } };

        private static List<Partner> PartnerToSeed = new List<Partner> {

          new Partner() { Guid =Guid.NewGuid(), Name ="partner 1" ,CreatedDate = new DateTime(), Site = SiteToSeed.FirstOrDefault(),CollaboratorRoleId = 1} ,
          new Partner() { Guid =Guid.NewGuid(),  Name ="partner 2" ,CreatedDate = new DateTime(), Site = SiteToSeed.FirstOrDefault(),CollaboratorRoleId = 1} ,


          new Partner() { Guid =Guid.NewGuid(),  Name ="partner 3" ,CreatedDate = new DateTime(), Site = SiteToSeed.FirstOrDefault(),CollaboratorRoleId = 2, Superior = PartnerToSeed.Where(p=> p.Name =="partner 1").FirstOrDefault()} ,
          new Partner() { Guid =Guid.NewGuid(),  Name ="partner 4" ,CreatedDate = new DateTime(), Site = SiteToSeed.FirstOrDefault(),CollaboratorRoleId = 2, Superior = PartnerToSeed.Where(p=> p.Name =="partner 1").FirstOrDefault()} ,
          new Partner() { Guid =Guid.NewGuid(),  Name ="partner 5" ,CreatedDate = new DateTime(), Site = SiteToSeed.FirstOrDefault(),CollaboratorRoleId = 2, Superior = PartnerToSeed.Where(p=> p.Name =="partner 1").FirstOrDefault()} ,


          new Partner() { Guid =Guid.NewGuid(),  Name ="partner 6" ,CreatedDate = new DateTime(), Site = SiteToSeed.FirstOrDefault(),CollaboratorRoleId = 3, Superior = PartnerToSeed.Where(p=> p.Name =="partner 3").FirstOrDefault()} ,
          new Partner() { Guid =Guid.NewGuid(),  Name ="partner 7" ,CreatedDate = new DateTime(), Site = SiteToSeed.FirstOrDefault(),CollaboratorRoleId = 3, Superior = PartnerToSeed.Where(p=> p.Name =="partner 3").FirstOrDefault()} ,
          new Partner() { Guid =Guid.NewGuid(),  Name ="partner 8" ,CreatedDate = new DateTime(), Site = SiteToSeed.FirstOrDefault(),CollaboratorRoleId = 4, Superior = PartnerToSeed.Where(p=> p.Name =="partner 5").FirstOrDefault()} ,
        };


        public List<Household> HouseholdToSeed()
        {
            List<Household> data = new List<Household>();

            for (int i = 0; i < 30; i++)
            {
                int rondomPartner = new Random().Next(6, 8);

                data.Add(new Household() { Guid = Guid.NewGuid(), Name = $@"Household {i}", CreatedDate = new DateTime(), Partner = PartnerToSeed.Where(p => p.Name == $"partner {rondomPartner}").FirstOrDefault() });

            }

            return data;
        }


    }


}
