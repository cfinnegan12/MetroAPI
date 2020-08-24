using System.Collections.Generic;
using MetroAPI.Data;
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
        ActionResult<IEnumerable<Journey>> GetAllJourneys()
        {
            var journeys = _repository.GetAllJourneys();
            return Ok(journeys);
        }

        [HttpGet("{id}")]
        ActionResult<Journey> GetJourneyById(int id)
        {
            var journey = _repository.GetJourneyById(id);
            return Ok(journey);
        }

        [HttpGet("route/{routeId}")]
        ActionResult<IEnumerable<Journey>> GetJourneysByRoute(int routeId)
        {
            var journeys = _repository.GetJourneysByRoute(routeId);
            return Ok(journeys);
        }

    }
}
