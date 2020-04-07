using System;
using System.Collections.Generic;
using domain.models;

namespace data.repositories.Interfaces
{
    public interface IClientRepository
    {
        public int Save<T>(T entity) where T : class;
        public bool Update<T>(T entity) where T : class;
        IEnumerable<Client> GetAll();
        public List<Client> GetClientByNameOrRGOrCPF(string searchValue);
        Client FindById(int createdInstructor);
    }
}
