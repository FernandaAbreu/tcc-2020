using System;
using AutoMapper;
using helpers;
using Microsoft.AspNetCore.Mvc;
using api.Extensions;
using api.services.Interfaces;
using api.viewmodels;
using ui.viewmodels;

namespace api.Controllers
{
   
        public class AuthController : Controller
        {
            private readonly IAuthService _authService;
            private readonly IMapper _mapper;

            public AuthController(IAuthService authService, IMapper mapper)
            {
                _authService = authService;
                _mapper = mapper;
            }
            [HttpGet]
            public ActionResult Index()
            {
                return View();
            }

        [HttpPost]
        public ActionResult<VMLoginResponse> Login([Bind("Email,Password")] VMLoginRequest payload)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var result = _authService.CreateAccessToken(payload.Email, payload.Password);
                        var url = Url.Content("~/Home");
                        return Redirect(url);
                    }
                        

                   
                }
                catch (CustomHttpException ex)
                {
                TempData["_mensagem"] = new VMMessages()
                {
                    Css = "alert alert-danger",
                    Text = ex.Message
                };
            }
                catch (Exception ex)
                {
                // TODO: Log ex
                TempData["_mensagem"] = new VMMessages()
                {
                    Css = "alert alert-danger",
                    Text = ex.Message
                };
            }
                return View(payload);
            }
        }
    
}
