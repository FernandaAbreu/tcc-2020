using System;
using System.Collections.Generic;
using api.Extensions;
using domain.models;
using helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using services.Interfaces;
using viewmodels;

namespace api.Controllers
{
    [Authorize]
    [Microsoft.AspNetCore.Components.Route("/api/payment")]
    public class PaymentController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public ActionResult<List<Payment>> list()
        {
            try
            {

                return _paymentService.GetPaymentsThatAreNotPaidAndNeeded();


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
        public ActionResult<List<Payment>> list([FromBody] VMSearchpayment payload)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                if (string.IsNullOrEmpty(payload.searchValue) || string.IsNullOrWhiteSpace(payload.searchValue))
                {
                    return _paymentService.GetPaymentsThatAreNotPaidAndNeeded();
                }
                else
                {
                    return _paymentService.GetPaymentsByNameOrRGOrCPF(payload.searchValue);
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
    }
}
