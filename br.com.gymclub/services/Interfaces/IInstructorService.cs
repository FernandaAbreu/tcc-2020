using System;
using System.Collections.Generic;
using domain.models;
using viewmodels;

namespace services.Interfaces
{
    public interface IInstructorService
    {
        public domain.models.Instructor Save<T>(VMInstructor entity) where T : class;
        public bool Update<T>(VMInstructor entity) where T : class;
        IEnumerable<Instructor> GetAll();
        public List<Instructor> GetInstructorByNameOrRGOrCPF(string searchValue);
    }
}
