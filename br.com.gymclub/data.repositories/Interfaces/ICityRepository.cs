using System;
using System.Collections.Generic;
using domain.models;

namespace data.repositories.Interfaces
{
    public interface ICityRepository
    {
        List<City> FindByStateId(int stateId);
    }
}
