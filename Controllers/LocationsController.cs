using System.Collections.Generic;
using MetroAPI.Data;
using MetroAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MetroAPI.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMetroRepo _repository;

        public LocationsController(IMetroRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Location>> GetAllLocations()
        {
            var locations = _repository.GetAllLocations();
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public ActionResult<Location> GetLocationFromId(int id)
        {
            var location = _repository.GetLocationFromId(id);
            return Ok(location);
        }

        [HttpGet("shortForm/{shortForm}")]
        public ActionResult<Location> GetLocationFromShortForm(string shortForm)
        {
            var location = _repository.GetLocationFromShortForm(shortForm);
            return Ok(location);
        }

        [HttpGet("fullForm/{fullForm}")]
        public ActionResult<Location> GetLocationFromFullForm(string fullForm)
        {
            var location = _repository.GetLocationFromShortForm(fullForm);
            return Ok(location);
        }
    }
}
