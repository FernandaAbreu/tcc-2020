using System;
using System.Collections.Generic;
using System.Linq;
using api.context;
using api.models;
using api.repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
                .Include(c => c.User)
                .Include(c => c.city)
                .Include(c => c.planType)
                .Include(c => c.state)
                .Include(c => c.typePayment)
                 .Where(u => u.IdRegistration == createdInstructor)
                 .SingleOrDefault();
        }

        public List<Client> GetAll()
        {
            return mcontexto.Client.Include(c => c.city)
                .Include(c => c.User)
                .Include(c => c.planType)
                .Include(c => c.state)
                .Include(c => c.typePayment)
                .Where(c => c.DeletedAt.HasValue.Equals(false)).ToList();
        }

        public List<Client> GetClientByNameOrRGOrCPF(string searchValue)
        {
            return mcontexto.Client.Include(c => c.city)
                .Include(c => c.User)
                .Include(c => c.planType)
                .Include(c => c.state)
                .Include(c => c.typePayment)
                .Where(c => c.User.Name.Contains(searchValue)
                || c.User.Rg.Contains(searchValue)
                || c.User.Cpf.Contains(searchValue)).ToList();

        }

        public int Save(Client entity)
        {
            var client = SaveEntity(entity);
            return client.IdRegistration;
        }

        bool IClientRepository.Update(Client entity, int codigo)
        {
            return Update(entity, codigo);
        }
    }
}
