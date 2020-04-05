using System;
using System.Collections.Generic;
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

        public IEnumerable<Instructor> GetAll()
        {
            return (System.Collections.Generic.IEnumerable<domain.models.Instructor>)Search<Instructor>(c => c.DeletedAt.HasValue.Equals(false));
        }

        bool IInstructorRepository.Update<Instructor>(Instructor entity)
        {
            return Update<Instructor>(entity);
        }
    }
}
