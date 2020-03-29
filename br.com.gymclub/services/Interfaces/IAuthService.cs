using System;
namespace services.Interfaces
{
    public interface IAuthService
    {
        User CreateAccessToken(string email, string password);
    }
}
