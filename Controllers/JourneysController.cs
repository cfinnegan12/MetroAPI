using System.Collections.Generic;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public JourneysController(IMetroRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Journey>> GetAllJourneys()
        {
            var journeys = _repository.GetAllJourneys();
            return Ok(journeys);
        }

        [HttpGet("{id}")]
        public ActionResult<JourneyReadDto> GetJourneyById(int id)
        {
            var journey = _repository.GetJourneyById(id);
            var response = _mapper.Map<JourneyReadDto>(journey);
            response.OperationDays = _mapper.Map<OperationDaysDto>(journey);
            return Ok(response);
        }

        [HttpGet("route/{routeId}")]
        public ActionResult<IEnumerable<Journey>> GetJourneysByRoute(int routeId)
        {
            var journeys = _repository.GetJourneysByRoute(routeId);
            return Ok(journeys);
        }

    }
}
