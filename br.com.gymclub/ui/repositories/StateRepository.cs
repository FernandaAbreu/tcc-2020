using System;
using System.Collections.Generic;
using System.Linq;
using api.context;
using api.models;
using api.repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.repositories
{
    public class StateRepository : Repository<State>, IStateRepository
    {
        public StateRepository(AppDbContext contexto) : base(contexto)
        {
        }

       

        public List<State> GetAll()
        {
            return SearchAll().OrderBy(c=>c.Name).ToList();
        }
    }
}
