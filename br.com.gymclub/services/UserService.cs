using System;
using data.Contexts;
using domain.models;
using helpers;
using services.Interfaces;

namespace services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordManager _passwordManager;

        public UserService(
            AppDbContext context,
            IUserRepository userRepository,
            IPasswordManager passwordManager
        )
        {
            _context = context;
            _userRepository = userRepository;
            _passwordManager = passwordManager;
        }


        public User Create(User user, int advertiserId)
        {
            throw new NotImplementedException();
        }

        public User FindByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public bool IsAdmin(int id)
        {
            throw new NotImplementedException();
        }
    }
}
