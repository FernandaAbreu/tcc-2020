using System;
using System.Collections.Generic;
using domain.models;

namespace services.Interfaces
{
    public interface IStateService
    {
        List<State> GetAll();
        
    }
}
