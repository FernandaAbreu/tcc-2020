using System;
using System.Collections.Generic;
using domain.models;

namespace data.repositories.Interfaces
{
    public interface IClientRepository
    {
        public int Save(Client entity);
        public bool Update(Client entity);
        public bool Remove(Client entity);
        List<Client> GetAll();
        public List<Client> GetClientByNameOrRGOrCPF(string searchValue);
        Client FindById(int createdInstructor);
    }
}
