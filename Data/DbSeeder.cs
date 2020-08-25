using MetroAPI.Models;
using ATCOcif;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Collections.Generic;

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
            if (!context.Journeys.Any()) SeedJourneys(context);

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

                    context.Routes.Add(new Route
                    {
                        RouteNumber = route.Route,
                        Description = route.Description,
                        Direction = route.Direction.ToString("G")
                    }); ;
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

        private static bool SeedJourneys(MetroDBContext context)
        {
            int i = 0;
            try
            {
                foreach (JourneyRecord journey in _parser.Journeys)
                {
                    Console.WriteLine("Seeding journeys: " + i + "/" + _parser.Journeys.Count);
                    Route journeyRoute = context.Routes
                        .Where(r => r.RouteNumber == journey.Header.Route && r.Direction == (journey.Header.Direction.ToString("G")))
                        .FirstOrDefault();

                    context.Journeys.Add(new Journey
                    {
                        Route = journeyRoute,
                        Monday = journey.Header.OperationDays[0],
                        Tuesday = journey.Header.OperationDays[1],
                        Wednesday = journey.Header.OperationDays[2],
                        Thursday = journey.Header.OperationDays[3],
                        Friday = journey.Header.OperationDays[4],
                        Saturday = journey.Header.OperationDays[5],
                        Sunday = journey.Header.OperationDays[6],
                        BankHolidays = journey.Header.BankHolidays,
                        Stops = StopsFromJourney(journey, context)
                    });
 
                    i++;
                }
                context.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine("Journey seeding failed: \n" + e.Message);
                return false;
            }

            Console.WriteLine("Journey successfully seeded");
            return true;
        }

        private static List<Stop> StopsFromJourney(JourneyRecord journeyRecord, MetroDBContext context)
        {
            List<Stop> result = new List<Stop>();
            result.Add(StopFromRecord(context, journeyRecord.Origin, 'O'));

            foreach (StopRecord record in journeyRecord.IntermediateRecords)
                result.Add(StopFromRecord(context, record, 'I'));

            result.Add(StopFromRecord(context, journeyRecord.Destination, 'D'));

            return result;
        }

        private static Stop StopFromRecord(MetroDBContext context, StopRecord record, char type = 'I')
        {
            Location location = context.Locations
                .Where(l => l.ShortForm == record.Location).FirstOrDefault();

            return new Stop
            {
                Location = location,
                Time = new TimeSpan(0, record.Time.Hours, record.Time.Minutes, record.Time.Seconds),
                StopType = type
            };
        }
    }
}
