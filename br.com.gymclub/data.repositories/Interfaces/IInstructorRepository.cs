using System;
using System.Collections.Generic;
using domain.models;

namespace data.repositories.Interfaces
{
    public interface IInstructorRepository
    {
        public int Save<T>(T entity) where T : class;
        public bool Update<T>(T entity) where T : class;
        IEnumerable<Instructor> GetAll();
        public List<Instructor> GetInstructorByNameOrRGOrCPF(string searchValue);
        public Instructor FindById(int id);
    }
}
