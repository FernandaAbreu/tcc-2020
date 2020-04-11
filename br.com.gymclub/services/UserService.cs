using System;
using data.repositories.Interfaces;
using datacontexts;
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
            var existingUser = _userRepository.FindByEmail(user.Email);
            if (existingUser != null)
            {
                throw new CustomHttpException(422, "This username is not available");
            }
            user.Password = _passwordManager.HashPassword(user.Password);
            var transaction = _context.Database.BeginTransaction();
            try
            {
                var createdUserId = _userRepository.Save(user);
             
                transaction.Commit();
                return _userRepository.FindById(createdUserId);
            }
            catch (Exception ex)
            {
                //TODO: Log ex
                transaction.Rollback();
                throw new CustomHttpException(500, "Internal server error");
            }
        }

        public User FindByEmail(string email)
        {
            var user = _userRepository.FindByEmail(email);
            if (user == null)
            {
                throw new CustomHttpException(422, "User doesn't exist");
            }
            return user;
        }

        public bool IsAdmin(int id)
        {
            var user = _userRepository.FindById(id);
            return user.UserTypeId == 1;
        }
        public bool IsRecepcionist(int id)
        {
            var user = _userRepository.FindById(id);
            return user.UserTypeId == 2;
        }
    }
}
