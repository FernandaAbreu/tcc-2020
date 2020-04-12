using System;
using System.Collections.Generic;
using api.Extensions;
using api.models;
using api.services.Interfaces;
using api.viewmodels;
using helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers
{
    [Authorize]
    [Route("/api/instructor")]
    public class InstructorController : Microsoft.AspNetCore.Mvc.ControllerBase
    {

        private readonly IInstructorService _instructorService;
       
        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }


        [HttpPost]
        [Authorize(Roles = "Recepcionista")]
        public ActionResult<Instructor> Create([FromBody] VMInstructor payload)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                var result = _instructorService.Save(payload);
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
        public ActionResult<Instructor> Update([FromBody] VMInstructor payload)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                var result = _instructorService.Update(payload);
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
        public ActionResult<Boolean> Delete([FromBody] Instructor payload)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }

                return _instructorService.Remove(payload);
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
        public ActionResult<List<Instructor>> Search([FromBody] VMSearchInstructor payload)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                if (string.IsNullOrEmpty(payload.searchValue) || string.IsNullOrWhiteSpace(payload.searchValue))
                {
                    return _instructorService.GetAll();
                }
                else
                {
                    return _instructorService.GetInstructorByNameOrRGOrCPF(payload.searchValue);
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
        public ActionResult<List<Instructor>> list()
        {
            try
            {

                return _instructorService.GetAll();


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
