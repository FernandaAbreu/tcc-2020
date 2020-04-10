using System;
using System.Collections.Generic;
using domain.models;
using viewmodels;

namespace services.Interfaces
{
    public interface IClientService
    {
        public Client Save<T>(VMClient entity) where T : class;
        public bool Update<T>(VMClient entity) where T : class;
        public bool Remove<T>(Client entity) where T : class;
        List<Client> GetAll();
        public List<Client> GetClientByNameOrRGOrCPF(string searchValue);
    }
}
