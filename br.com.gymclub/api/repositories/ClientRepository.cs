using System;
using System.Collections.Generic;
using System.Linq;
using api.context;
using api.models;
using api.repositories.Interfaces;

namespace api.repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(AppDbContext contexto) : base(contexto)
        {
        }

        public Client FindById(int createdInstructor)
        {
            return mcontexto.Client
                 .Where(u => u.IdRegistration == createdInstructor)
                 .SingleOrDefault();
        }

        public List<Client> GetAll()
        {
            return (System.Collections.Generic.List<Client>)Search(c => c.DeletedAt.HasValue.Equals(false));
        }

        public List<Client> GetClientByNameOrRGOrCPF(string searchValue)
        {
            return (System.Collections.Generic.List<Client>)Search(c => c.User.Name.Contains(searchValue) || c.User.Rg.Contains(searchValue) || c.User.Cpf.Contains(searchValue));

        }
        bool IClientRepository.Update(Client entity)
        {
            return Update(entity);
        }
    }
}
