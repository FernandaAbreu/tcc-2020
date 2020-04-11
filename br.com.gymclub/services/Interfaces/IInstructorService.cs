using System;
using System.Collections.Generic;
using domain.models;
using viewmodels;

namespace services.Interfaces
{
    public interface IInstructorService
    {
        public domain.models.Instructor Save(VMInstructor entity);
        public bool Update(VMInstructor entity);
        List<Instructor> GetAll();
        public bool Remove(Instructor entity);
        public List<Instructor> GetInstructorByNameOrRGOrCPF(string searchValue);
    }
}
