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
            if (!context.Routes.Any()) SeedRoutes(context);

        }

        private static bool SeedLocations(MetroDBContext context)
        {
            int i = 0;
            try
            {

                foreach (LocationRecord location in _parser.Locations.Values)
                {
                    Console.WriteLine("Seeding locations: " + i + "/" + _parser.Locations.Count);

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

        private static bool SeedRoutes(MetroDBContext context)
        {
            int i = 0;
            try
            {
                foreach (RouteDescription route in _parser.Routes.Values)
                {
                    Console.WriteLine("Seeding routes: " + i + "/" + _parser.Routes.Count);

                    context.Routes.Add(new Route { 
                        RouteNumber = route.Route,
                        Description = route.Description,
                        Direction = (route.Direction == Direction.Inbound) ? "Inbound" : "Outbound"
                    });
                    i++;
                }
                context.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine("Routes seeding failed: \n" + e.Message);
                return false;
            }

            Console.WriteLine("Routes successfully seeded");
            return true;
        }
    }
}
