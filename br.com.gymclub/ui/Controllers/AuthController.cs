using System;
using AutoMapper;
using helpers;
using Microsoft.AspNetCore.Mvc;
using api.Extensions;
using api.services.Interfaces;
using api.viewmodels;
using ui.viewmodels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using api.models;

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
            [HttpGet]
            public ActionResult withoutaccess()
            {
                return View();
            }

        [HttpPost]
        public async Task<IActionResult> Index([Bind("Email,Password")] VMLoginRequest payload)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                       User user= _authService.CreateAccessToken(this.HttpContext,payload.Email, payload.Password);
                    var claimsIdentity = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name,user.Id.ToString()),
                            new Claim(ClaimTypes.Role,user.UserType.Name)
                        }, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    var authProperties = new AuthenticationProperties { };
                    await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            authProperties);
                    var url = Url.Content("~/Home");
                        return Redirect(url);
                    }
                        

                   
                }
                catch (CustomHttpException ex)
                {
                    TempData["_mensagem"] = new VMMessages()
                    {
                        Css = "alert alert-danger",
                        Text = ex.ErrorMessage
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
