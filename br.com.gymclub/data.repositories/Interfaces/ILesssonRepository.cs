using System;
using System.Collections.Generic;
using domain.models;

namespace data.repositories.Interfaces
{
    public interface ILesssonRepository
    {
        public int Save(Lesson entity);
        public bool Update(Lesson entity);
        IEnumerable<Lesson> GetAll();
    }
}
