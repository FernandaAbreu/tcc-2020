using System;
using System.Collections.Generic;
using domain.models;

namespace services.Interfaces
{
    public interface ICityService
    {
        List<City> GetCitiesByState(int stateId);
    }
}
