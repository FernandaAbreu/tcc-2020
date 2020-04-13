using System;
using System.Collections.Generic;
using api.models;

namespace api.repositories.Interfaces
{
    public interface ILesssonRepository
    {
        public int Save(Lesson entity);
        public bool Update(Lesson entity);
        IEnumerable<Lesson> GetAll();
    }
}
