using System;
using System.Collections.Generic;
using domain.models;

namespace data.repositories.Interfaces
{
    public interface IStateRepository
    {
        List<State> GetAll();
    }
}
