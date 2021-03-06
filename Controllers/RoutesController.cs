﻿using MetroAPI.Data;
using MetroAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
        public ActionResult<IEnumerable<Route>> GetAllRoutes()
        {
            var routes = _repository.GetAllRoutes();
            return Ok(routes);
        }

        [HttpGet("{id}")]
        public ActionResult<Route> GetRouteById(int id)
        {
            var route = _repository.GetRouteById(id);
            if (route == null) return NotFound();
            return Ok(route);
        }

        [HttpGet("routeNumber/{routeNumber}")]
        public ActionResult<IEnumerable<Route>> GetRoutesFromRouteNumber(string routeNumber)
        {
            var routes = _repository.GetRoutesFromRouteNumber(routeNumber);
            if (routes.Count() == 0 || routes == null) return NotFound();
            else return Ok(routes);
        }
    }
}
