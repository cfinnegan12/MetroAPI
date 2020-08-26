using System.Collections.Generic;
using AutoMapper;
using MetroAPI.Data;
using MetroAPI.DTOs;
using MetroAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MetroAPI.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMetroRepo _repository;
        private readonly IMapper _mapper;

        public LocationsController(IMetroRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Location>> GetAllLocations()
        {
            var locations = _repository.GetAllLocations();
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public ActionResult<LocationReadDto> GetLocationFromId(int id)
        {
            var location = _repository.GetLocationFromId(id);
            return Ok(_mapper.Map<LocationReadDto>(location));
        }

        [HttpGet("shortForm/{shortForm}")]
        public ActionResult<Location> GetLocationFromShortForm(string shortForm)
        {
            var location = _repository.GetLocationFromShortForm(shortForm);
            return Ok(location);
        }

        [HttpGet("fullForm/{fullForm}")]
        public ActionResult<IEnumerable<Location>> GetLocationsFromFullForm(string fullForm)
        {
            var location = _repository.GetLocationsFromFullForm(fullForm);
            return Ok(location);
        }
    }
}
