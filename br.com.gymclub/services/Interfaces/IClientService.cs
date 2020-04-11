using System;
using System.Collections.Generic;
using domain.models;
using viewmodels;

namespace services.Interfaces
{
    public interface IClientService
    {
        public Client Save(VMClient entity);
        public bool Update(VMClient entity) ;
        public bool Remove(Client entity);
        List<Client> GetAll();
        public List<Client> GetClientByNameOrRGOrCPF(string searchValue);
    }
}
