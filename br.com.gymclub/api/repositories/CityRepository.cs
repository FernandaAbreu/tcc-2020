using System;
using System.Collections.Generic;
using api.context;
using api.models;
using api.repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(AppDbContext contexto) : base(contexto)
        {
        }
        public List<City> FindByStateId(int stateId) => (System.Collections.Generic.List<City>)Search(c => c.state_id.Equals(stateId));

        
    }
}
