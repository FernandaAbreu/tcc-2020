using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using services.Interfaces;

namespace api.Controllers
{
    [Authorize]
    [Route("/api/payment")]
    public class PaymentController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
    }
}
