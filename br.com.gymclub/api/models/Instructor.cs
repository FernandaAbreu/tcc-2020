using System;
using System.Collections.Generic;

namespace api.models
{
    public class Instructor
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int userId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public User User { get; set; }
        public State state { get; set; }
        public City city { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public int idCity { get; set; }
        public int idState { get; set; }
        public IEnumerable<Lesson> lessons { get; set; }
    }
}
