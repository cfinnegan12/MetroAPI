using System.Collections.Generic;
using System.Linq;
using MetroAPI.Data;
using MetroAPI.DTOs;
using MetroAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MetroAPI.Controllers
{
    [Route("api/journeys")]
    [ApiController]
    public class JourneysController : ControllerBase
    {

        private readonly IMetroRepo _repository;

        public JourneysController(IMetroRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<JourneyReadDTO>> GetAllJourneys()
        {
            var journeys = _repository.GetAllJourneys();
            return Ok(journeys.Select(j => new JourneyReadDTO(j)));
        }

        [HttpGet("{id}")]
        public ActionResult<JourneyReadDTO> GetJourneyById(int id)
        {
            var journey = _repository.GetJourneyById(id);
            if (journey == null) return NotFound();
            else return Ok(new JourneyReadDTO(journey));
        }

        [HttpGet("route/{routeId}")]
        public ActionResult<IEnumerable<JourneyReadDTO>> GetJourneysByRoute(int routeId)
        {
            var journeys = _repository.GetJourneysByRoute(routeId);
            if (journeys.Count() == 0 || journeys == null) return NotFound();
            else return Ok(journeys.Select(j => new JourneyReadDTO(j)));
        }

    }
}
