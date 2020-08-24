using MetroAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroAPI.Data
{
    public class TestRepo : IMetroRepo
    {
        public IEnumerable<Journey> GetAllJourneys()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> GetAllLocations()
        {
            var locations = new List<Location>
            {
                new Location { Id = 0,ShortForm = "1234567",FullForm = "Test Full Form Location",GridEasting = 123456,GridNorthing = 654321},
                new Location { Id = 1,ShortForm = "2345678",FullForm = "Test Full Form Location2",GridEasting = 123456,GridNorthing = 654321},
                new Location { Id = 2,ShortForm = "3456789",FullForm = "Test Full Form Location3",GridEasting = 123456,GridNorthing = 654321},
                new Location { Id = 3,ShortForm = "4567890",FullForm = "Test Full Form Location4",GridEasting = 123456,GridNorthing = 654321 }
            };
            return locations;
        }

        public IEnumerable<Route> GetAllRoutes()
        {
            throw new NotImplementedException();
        }

        public Journey GetJourneyById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Journey> GetJourneysByRoute(int routeId)
        {
            throw new NotImplementedException();
        }

        public Location GetLocationFromFullForm(string fullForm)
        {
            throw new NotImplementedException();
        }

        public Location GetLocationFromId(int id)
        {
            return new Location
            {
                Id = 0,
                ShortForm = "1234567",
                FullForm = "Test Full Form Location",
                GridEasting = 123456,
                GridNorthing = 654321
            };
        }

        public Location GetLocationFromShortForm(string shortForm)
        {
            throw new NotImplementedException();
        }

        public Route GetRouteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Route> GetRoutesFromRouteNumber(string routeNumber)
        {
            throw new NotImplementedException();
        }

        public Stop GetStopFromId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Stop> GetStopsFromTime(string time)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Stop> GetStopsAlongJourney(int journeyId)
        {
            throw new NotImplementedException();
        }
    }
}
