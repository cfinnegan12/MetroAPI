using System.Collections.Generic;
using MetroAPI.Data;
using MetroAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MetroAPI.Controllers
{
    [Route("api/stops")]
    [ApiController]
    public class StopsController : ControllerBase
    {
        private readonly IMetroRepo _repository;

        public StopsController(IMetroRepo repository)
        {
            _repository = repository;
        }

        [HttpGet("journey/{journeyId}")]
        ActionResult<IEnumerable<Stop>> GetStopsAlongJourney(int journeyId)
        {
            var stops = _repository.GetStopsAlongJourney(journeyId);
            return Ok(stops);
        }

        [HttpGet("{id}")]
        ActionResult<Stop> GetStopFromId(int id)
        {
            var stop = _repository.GetStopFromId(id);
            return Ok(stop);
        }

        [HttpGet("time/{time}")]
        ActionResult<IEnumerable<Stop>> GetStopsAtTime(string time)
        {
            var stops = _repository.GetStopsFromTime(time);
            return Ok(stops);
        }
    }
}
