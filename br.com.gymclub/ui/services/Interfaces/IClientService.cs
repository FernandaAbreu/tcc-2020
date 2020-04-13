using System;
using System.Collections.Generic;
using api.models;
using api.viewmodels;

namespace api.services.Interfaces
{
    public interface IClientService
    {
        public Client Save(VMClient entity);
        public bool Update(VMClient entity) ;
        public bool Remove(Client entity);
        List<Client> GetAll();
        public List<Client> GetClientByNameOrRGOrCPF(string searchValue);
        Client findById(int id);
    }
}
