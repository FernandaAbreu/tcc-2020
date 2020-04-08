using System;
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
                var result = _clientService.Save<VMClient>(payload);
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
                var result = _clientService.Update<VMClient>(payload);
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
        public ActionResult<Client> Delete([FromBody] VMClient payload)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                //var result = _clientService.Remove<VMClient>(payload);
                //return Ok(result);
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
