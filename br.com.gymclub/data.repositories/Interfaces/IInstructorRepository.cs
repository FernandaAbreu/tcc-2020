using System;
using System.Collections.Generic;
using domain.models;

namespace data.repositories.Interfaces
{
    public interface IInstructorRepository
    {
        public int Save(Instructor entity);
        public bool Update(Instructor entity);
        public bool Remove(Instructor entity);
        List<Instructor> GetAll();
        public List<Instructor> GetInstructorByNameOrRGOrCPF(string searchValue);
        public Instructor FindById(int id);
    }
}
