using System;
using api.models;
using Microsoft.AspNetCore.Http;

namespace api.services.Interfaces
{
    public interface IAuthService
    {
          User CreateAccessToken(HttpContext httpContext, string email, string password);
    }
}
