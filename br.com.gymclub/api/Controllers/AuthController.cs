using System;
using AutoMapper;
using helpers;
using Microsoft.AspNetCore.Mvc;
using services.Interfaces;
using viewmodels;
using api.Extensions;

namespace api.Controllers
{
   
        public class AuthController : ControllerBase
        {
            private readonly IAuthService _authService;
            private readonly IMapper _mapper;

            public AuthController(IAuthService authService, IMapper mapper)
            {
                _authService = authService;
                _mapper = mapper;
            }

            [HttpPost]
            [Route("/api/login")]
            public ActionResult<VMLoginResponse> Login([FromBody] VMLoginRequest payload)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState.GetErrorMessages());

                    var result = _authService.CreateAccessToken(payload.Email, payload.Password);
                    return Ok(_mapper.Map<VMLoginResponse>(result));
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
