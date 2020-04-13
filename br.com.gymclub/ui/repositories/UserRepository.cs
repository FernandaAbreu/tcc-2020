using System;
using System.Collections.Generic;
using System.Linq;
using api.context;
using api.models;
using api.repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext contexto) : base(contexto)
        {
        }

        public User FindByCPF(string cpf)
        {
            return mcontexto.User
                 .Include(p => p.UserType)
                 .Where(u => u.Cpf == cpf)
                 .SingleOrDefault();
        }

        public User FindByEmail(string email)
        {
            return mcontexto.User
                 .Include(p => p.UserType)
                 .Where(u => u.Email == email)
                 .SingleOrDefault();
        }

        public User FindById(int id)
        {
            return mcontexto.User
                 .Include(p => p.UserType)
                 .Where(u => u.Id == id)
                 .SingleOrDefault();
        }

        public User FindByRg(string rg)
        {
            return mcontexto.User
                  .Include(p => p.UserType)
                  .Where(u => u.Rg == rg)
                  .SingleOrDefault();
        }

        int IUserRepository.Save(User entity)
        {
            var user = this.SaveEntity(entity);
            return user.Id;
        }
    }
}
