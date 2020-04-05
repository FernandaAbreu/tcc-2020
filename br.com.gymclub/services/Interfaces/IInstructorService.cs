using System;
namespace services.Interfaces
{
    public interface IInstructorService
    {
        public int Save<T>(T entity) where T : class;
        public bool Update<T>(T entity) where T : class;
        IEnumerable<Instructor> GetAll();
        public List<Instructor> GetInstructorByNameOrRGOrCPF(string searchValue);
    }
}
