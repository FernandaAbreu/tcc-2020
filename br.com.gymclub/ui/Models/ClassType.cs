using System;
using System.Collections.Generic;

namespace api.models
{
    public class ClassType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public IEnumerable<Lesson> lessons { get; set; }

    }


    
 
}