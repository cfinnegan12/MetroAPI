
using MetroAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroAPI.Data
{
    public interface IMetroRepo
    {
        /*
         * Journeys
         */
        IEnumerable<Journey> GetAllJourneys();
        IEnumerable<Journey> GetJourneysByRoute(int routeId);
        Journey GetJourneyById(int id);

        /*
         * Stops
         */
        IEnumerable<Stop> GetStopsAlongJourney(int journeyId);
        Stop GetStopFromId(int id);
        IEnumerable<Stop> GetStopsFromTime(string time);


        /*
         * Locations
         */
        IEnumerable<Location> GetAllLocations();
        Location GetLocationFromId(int id);
        Location GetLocationFromShortForm(string shortForm);
        Location GetLocationFromFullForm(string fullForm);


        /*
         * Routes
         */
        IEnumerable<Route> GetAllRoutes();
        Route GetRouteById(int id);
        IEnumerable<Route> GetRoutesFromRouteNumber(string routeNumber);
    }
}
