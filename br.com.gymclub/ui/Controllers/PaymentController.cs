﻿using System;
using System.Collections.Generic;
using api.Extensions;
using api.models;
using api.services.Interfaces;
using api.viewmodels;
using helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;


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
               
                 var finalDate = DateTime.Now;
                
                 var initDate = DateTime.MinValue;
                

                return _paymentService.GetPaymentsThatAreNotPaidAndNeeded(initDate, finalDate);


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
                if (payload.finalDate == null)
                {
                    payload.finalDate = DateTime.Now;
                }
                if (payload.initDate == null)
                {
                    payload.initDate = DateTime.MinValue;
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                if (string.IsNullOrEmpty(payload.searchValue) || string.IsNullOrWhiteSpace(payload.searchValue))
                {
                    return _paymentService.GetPaymentsThatAreNotPaidAndNeeded(payload.initDate.Value,payload.finalDate.Value);
                }
                else
                {
                    return _paymentService.GetPaymentsByNameOrRGOrCPF(payload.searchValue, payload.initDate.Value, payload.finalDate.Value);
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
