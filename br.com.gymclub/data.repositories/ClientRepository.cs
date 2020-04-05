using System;
using System.Collections.Generic;
using data.Contexts;
using data.repositories.Interfaces;
using domain.models;

namespace data.repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(AppDbContext contexto) : base(contexto)
        {
        }
        public IEnumerable<Client> GetAll()
        {
            return (System.Collections.Generic.IEnumerable<domain.models.Client>)Search<Client>(c => c.DeletedAt.HasValue.Equals(false));
        }

        public List<Client> GetClientByNameOrRGOrCPF(string searchValue)
        {
            return (System.Collections.Generic.List<domain.models.Client>)Search<Client>(c => c.User.Name.Contains(searchValue) || c.User.Rg.Contains(searchValue) || c.User.Cpf.Contains(searchValue));

        }
        bool IClientRepository.Update<Client>(Client entity)
        {
            return Update<Client>(entity);
        }
    }
}
