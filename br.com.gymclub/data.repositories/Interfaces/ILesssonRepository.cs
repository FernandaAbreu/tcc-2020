using System;
using System.Collections.Generic;
using domain.models;

namespace data.repositories.Interfaces
{
    public interface ILesssonRepository
    {
        public int Save<T>(T entity) where T : class;
        public bool Update<T>(T entity) where T : class;
        IEnumerable<Lesson> GetAll();
    }
}
