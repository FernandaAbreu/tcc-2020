using System;
using System.Collections.Generic;
using data.Contexts;
using data.repositories.Interfaces;
using domain.models;

namespace data.repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(AppDbContext contexto) : base(contexto)
        {
        }
        public IEnumerable<City> FindByStateId(int stateId)
        {
            throw new NotImplementedException();
        }
    }
}
