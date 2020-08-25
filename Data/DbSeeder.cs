using MetroAPI.Models;
using ATCOcif;
using Microsoft.EntityFrameworkCore.Internal;
using System;

namespace MetroAPI.Data
{
    public static class DbSeeder
    {
        private static readonly ATCOcifParser _parser = new ATCOcifParser("./mtt_MET20200629v1.cif");

        public static void SeedDB(MetroDBContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Locations.Any()) SeedLocations(context);
            
        }

        private static bool SeedLocations(MetroDBContext context)
        {
            int i = 0;
            try
            {
                Console.WriteLine("Seeding locations: " + i + "/" + _parser.Locations.Count);
                foreach (LocationRecord location in _parser.Locations.Values)
                {
                    context.Locations.Add(new Location
                    {
                        ShortForm = location.Location,
                        FullForm = location.FullLocation,
                        GridEasting = location.GridEasting,
                        GridNorthing = location.GridNorthing
                    });
                    i++;
                }
                context.SaveChanges();

            } catch(Exception e)
            {
                Console.WriteLine("Locations seeding failed: \n" + e.Message);
                return false;
            } 

            Console.WriteLine("Locations successfully seeded");
            return true;
        }
    }
}
