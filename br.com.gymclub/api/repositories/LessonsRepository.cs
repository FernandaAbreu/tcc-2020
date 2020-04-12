using System;
using System.Collections.Generic;
using api.context;
using api.models;
using api.repositories.Interfaces;

namespace api.repositories
{
    public class LessonsRepository : Repository<Lesson>, ILesssonRepository
    {
        public LessonsRepository(AppDbContext contexto) : base(contexto)
        {
        }

        public IEnumerable<Lesson> GetAll()
        {
            return (System.Collections.Generic.IEnumerable<Lesson>)Search(c => c.DeletedAt.HasValue.Equals(false));

        }


    }
}
