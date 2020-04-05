using System;
using System.Collections.Generic;
using data.Contexts;
using data.repositories.Interfaces;
using domain.models;
using Microsoft.EntityFrameworkCore;

namespace data.repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(AppDbContext contexto) : base(contexto)
        {
        }
        public List<City> FindByStateId(int stateId) => (System.Collections.Generic.List<domain.models.City>)Search<City>(c => c.state_id.Equals(stateId));

        
    }
}
