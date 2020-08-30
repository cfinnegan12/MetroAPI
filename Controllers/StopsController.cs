using System.Collections.Generic;
using System.Linq;
using MetroAPI.Data;
using MetroAPI.DTOs;
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
        public ActionResult<IEnumerable<Stop>> GetStopsAlongJourney(int journeyId)
        {
            var stops = _repository.GetStopsAlongJourney(journeyId);
            if (stops.Count() == 0 || stops == null) return NotFound();
            else return Ok(stops.Select( s => new StopReadDTO(s)));
        }

        [HttpGet("{id}")]
        public ActionResult<StopReadDTO> GetStopFromId(int id)
        {
            var stop = _repository.GetStopFromId(id);
            if (stop == null) return NotFound();
            else return Ok(new StopReadDTO(stop));
        }

        [HttpGet("time/{time}")]
        public ActionResult<IEnumerable<Stop>> GetStopsAtTime(string time)
        {
            var stops = _repository.GetStopsFromTime(time);
            if (stops.Count() == 0 || stops == null) return NotFound();
            else return Ok(stops.Select(s => new StopReadDTO(s)));
        }
    }
}
