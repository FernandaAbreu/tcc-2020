using System;
using api.models;

namespace api.services.Interfaces
{
    public interface IAuthService
    {
        User CreateAccessToken(string email, string password);
    }
}
