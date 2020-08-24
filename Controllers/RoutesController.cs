using MetroAPI.Data;
using MetroAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MetroAPI.Controllers
{
    [Route("api/routes")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly IMetroRepo _repository;

        public RoutesController(IMetroRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        ActionResult<IEnumerable<Route>> GetAllRoutes()
        {
            var routes = _repository.GetAllRoutes();
            return Ok(routes);
        }

        [HttpGet("{id}")]
        ActionResult<Route> GetRouteById(int id)
        {
            var route = _repository.GetRouteById(id);
            return Ok(route);
        }

        [HttpGet("routeNumber/{routeNumber}")]
        ActionResult<IEnumerable<Route>> GetRoutesFromRouteNumber(string routeNumber)
        {
            var routes = _repository.GetRoutesFromRouteNumber(routeNumber);
            return Ok(routes);
        }
    }
}
