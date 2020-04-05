using System;
using domain.models;

namespace services.Interfaces
{
    public interface IAuthService
    {
        User CreateAccessToken(string email, string password);
    }
}
