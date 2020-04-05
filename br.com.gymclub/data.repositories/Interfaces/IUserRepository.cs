using System;
using domain.models;

namespace data.repositories.Interfaces
{
    public interface IUserRepository
    {
        public int Save<T>(T entity) where T : class;
        User FindByEmail(string email);
        User FindById(int id);
        User FindByCPF(string email);
        User FindByRg(string email);
        bool Update(User user);
    }
}
