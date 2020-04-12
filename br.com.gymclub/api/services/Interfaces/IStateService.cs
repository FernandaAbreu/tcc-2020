using System;
using System.Collections.Generic;
using api.models;

namespace api.services.Interfaces
{
    public interface IStateService
    {
        List<State> GetAll();
        
    }
}
