using System;
using System.Collections.Generic;
using System.Linq;
using data.Contexts;
using data.repositories.Interfaces;
using domain.models;
using Microsoft.EntityFrameworkCore;

namespace data.repositories
{
    public class StateRepository : Repository<State>, IStateRepository
    {
        public StateRepository(AppDbContext contexto) : base(contexto)
        {
        }

       

        public List<State> GetAll()
        {
            return SearchAll<State>();
        }
    }
}
