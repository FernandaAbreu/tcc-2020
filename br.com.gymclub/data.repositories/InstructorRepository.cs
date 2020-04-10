using System;
using System.Collections.Generic;
using System.Linq;
using data.Contexts;
using data.repositories.Interfaces;
using domain.models;

namespace data.repositories
{
    public class InstructorRepository : Repository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(AppDbContext contexto) : base(contexto)
        {
        }

        public List<Instructor> GetAll()
        {
            return (System.Collections.Generic.List<domain.models.Instructor>)Search<Instructor>(c => c.DeletedAt.HasValue.Equals(false));
        }

        public Instructor FindById(int id)
        {
            return mcontexto.Instructor
                 .Where(u => u.Id == id)
                 .SingleOrDefault();
        }
        public List<Instructor> GetInstructorByNameOrRGOrCPF(string searchValue)
        {
            return (System.Collections.Generic.List<domain.models.Instructor>)Search<Instructor>(c => c.User.Name.Contains(searchValue) || c.User.Rg.Contains(searchValue) || c.User.Cpf.Contains(searchValue));

        }

        bool IInstructorRepository.Update<Instructor>(Instructor entity)
        {
            return Update<Instructor>(entity);
        }
    }
}
