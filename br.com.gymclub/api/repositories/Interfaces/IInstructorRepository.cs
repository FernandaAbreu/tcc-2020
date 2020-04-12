using System;
using System.Collections.Generic;
using api.models;

namespace api.repositories.Interfaces
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
