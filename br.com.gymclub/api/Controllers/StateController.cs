﻿using System;
using System.Collections.Generic;
using api.models;
using api.services.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers
{
    
    [Route("/api/state")]
    public class StateController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private readonly IStateService _stateService;
        private readonly ICityService _cityService;
        public StateController(IStateService stateService,ICityService cityService)
        {
            _stateService = stateService;
            _cityService = cityService;
        }

        [HttpGet]
        //[Authorize(Roles = "Recepcionista")]
        public ActionResult<IEnumerable<State>> Get()
        {
            try
            {
                var countries = _stateService.GetAll();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                // TODO: log ex
                return StatusCode(500, new { error = "Internal server error" });
            }

        }
        [HttpGet("{id}/cities")]
        public ActionResult<IEnumerable<City>> GetCityByCountry(int id)
        {
            try
            {
                var cities = _cityService.GetCitiesByState(id);
                return Ok(cities);
            }
            catch (Exception ex)
            {
                // TODO: log ex
                return StatusCode(500, new { error = "Internal server error" });
            }
        }
    }
}
