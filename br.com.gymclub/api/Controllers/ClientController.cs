using System;
using System.Collections.Generic;
using api.Extensions;
using domain.models;
using helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using services.Interfaces;
using viewmodels;

namespace api.Controllers
{
    [Authorize]
    [Route("/api/client")]
    public class ClientController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        

        [HttpPost]
        [Authorize(Roles = "Recepcionista")]
        public ActionResult<Client> Create([FromBody] VMClient payload)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                var result = _clientService.Save(payload);
                return Ok(result);
            }
            catch (CustomHttpException ex)
            {
                return StatusCode(ex.StatusCode, ex.ErrorMessage);
            }
            catch (Exception ex)
            {
                // TODO: Log ex
                return StatusCode(500, new { error = "Internal server error" });
            }
        }
        [HttpPost]
        [Authorize(Roles = "Recepcionista")]
        public ActionResult<Client> Update([FromBody] VMClient payload)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                var result = _clientService.Update(payload);
                return Ok(result);
            }
            catch (CustomHttpException ex)
            {
                return StatusCode(ex.StatusCode, ex.ErrorMessage);
            }
            catch (Exception ex)
            {
                // TODO: Log ex
                return StatusCode(500, new { error = "Internal server error" });
            }
        }
        [HttpPost]
        [Authorize(Roles = "Recepcionista")]
        public ActionResult<Boolean> Delete([FromBody] Client payload)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                
                return _clientService.Remove(payload);
            }
            catch (CustomHttpException ex)
            {
                return StatusCode(ex.StatusCode, ex.ErrorMessage);
            }
            catch (Exception ex)
            {
                // TODO: Log ex
                return StatusCode(500, new { error = "Internal server error" });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Recepcionista")]
        public ActionResult<List<Client>> Search([FromBody] VMSearchClient payload)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                if (string.IsNullOrEmpty(payload.searchValue) || string.IsNullOrWhiteSpace(payload.searchValue))
                {
                    return _clientService.GetAll();
                }
                else
                {
                    return _clientService.GetClientByNameOrRGOrCPF(payload.searchValue);
                }
                
            }
            catch (CustomHttpException ex)
            {
                return StatusCode(ex.StatusCode, ex.ErrorMessage);
            }
            catch (Exception ex)
            {
                // TODO: Log ex
                return StatusCode(500, new { error = "Internal server error" });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Recepcionista")]
        public ActionResult<List<Client>> Get()
        {
            try
            {
               
               return _clientService.GetAll();
                

            }
            catch (CustomHttpException ex)
            {
                return StatusCode(ex.StatusCode, ex.ErrorMessage);
            }
            catch (Exception ex)
            {
                // TODO: Log ex
                return StatusCode(500, new { error = "Internal server error" });
            }
        }
    }
}
