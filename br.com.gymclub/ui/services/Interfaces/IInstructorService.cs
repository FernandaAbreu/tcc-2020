using System;
using System.Collections.Generic;
using api.models;
using api.viewmodels;

namespace api.services.Interfaces
{
    public interface IInstructorService
    {
        public Instructor Save(VMInstructor entity);
        public bool Update(VMInstructor entity);
        List<Instructor> GetAll();
        public bool Remove(Instructor entity);
        public List<Instructor> GetInstructorByNameOrRGOrCPF(string searchValue);
        Instructor findById(int id);
    }
}
