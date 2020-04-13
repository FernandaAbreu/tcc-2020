using System;
using api.models;

namespace api.repositories.Interfaces
{
    public interface IUserRepository
    {
        public int Save(User entity);
        User FindByEmail(string email);
        User FindById(int id);
        User FindByCPF(string email);
        User FindByRg(string email);
        bool Update(User user,int codigo);
    }
}
