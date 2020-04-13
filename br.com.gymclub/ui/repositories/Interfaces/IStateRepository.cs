using System;
using System.Collections.Generic;
using api.models;

namespace api.repositories.Interfaces
{
    public interface IStateRepository
    {
        List<State> GetAll();
    }
}
