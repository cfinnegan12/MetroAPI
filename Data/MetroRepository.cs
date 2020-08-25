using MetroAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MetroAPI.Data
{
    public class MetroRepository : IMetroRepo
    {
        private MetroDBContext _context;

        public MetroRepository(MetroDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Journey> GetAllJourneys()
        {

            return _context.Journeys;
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return _context.Locations;
        }

        public IEnumerable<Route> GetAllRoutes()
        {
            return _context.Routes;
        }

        public Journey GetJourneyById(int id)
        {
            return _context.Journeys.Where(j => j.Id == id).SingleOrDefault();
        }

        public IEnumerable<Journey> GetJourneysByRoute(int routeId)
        {
            return _context.Journeys.Where(j => j.Route.Id == routeId);
        }

        public IEnumerable<Location> GetLocationsFromFullForm(string fullForm)
        {
            return _context.Locations.Where(l => l.FullForm == fullForm);
        }

        public Location GetLocationFromId(int id)
        {
            return _context.Locations.Where(l => l.Id == id).SingleOrDefault();
        }

        public Location GetLocationFromShortForm(string shortForm)
        {
            return _context.Locations.Where(l => l.ShortForm == shortForm).FirstOrDefault();
        }

        public Route GetRouteById(int id)
        {
            return _context.Routes.Where(r => r.Id == id).SingleOrDefault();
        }

        public IEnumerable<Route> GetRoutesFromRouteNumber(string routeNumber)
        {
            return _context.Routes.Where(r => r.RouteNumber == routeNumber);
        }

        public Stop GetStopFromId(int id)
        {
            return _context.Stops.Where(s => s.Id == id).SingleOrDefault();
        }

        public IEnumerable<Stop> GetStopsAlongJourney(int journeyId)
        {
            return _context.Journeys.Where(j => j.Id == journeyId).SingleOrDefault().Stops;
        }

        public IEnumerable<Stop> GetStopsFromTime(string time)
        {
            int hours = Int16.Parse(time.Substring(0, 2));
            int mins = Int16.Parse(time.Substring(2, 2));
            return _context.Stops.Where(s => s.Time.Hours == hours && s.Time.Minutes == mins);
        }
    }
}
