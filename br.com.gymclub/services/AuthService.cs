using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using domain.models;
using helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using services.Interfaces;
using settings;

namespace services
{
    public class AuthService
    {
        private readonly IPasswordManager _passwordManager;
        private readonly IUserService _userService;
        private readonly AppSettings _appSettings;


        public AuthService(IPasswordManager passwordManager, IUserService userService, IOptions<AppSettings> appSettings)
        {
            _passwordManager = passwordManager;
            _userService = userService;
            _appSettings = appSettings.Value;
        }

        public User CreateAccessToken(string email, string password)
        {
            var user = _userService.FindByEmail(email);
            if (user == null || !_passwordManager.PasswordMatches(password, user.Password))
            {
                throw new CustomHttpException(422, "Invalid credentials");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.JWTSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.UserType.Name)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            return user;
        }
    }

}
