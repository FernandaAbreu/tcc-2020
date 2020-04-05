using System;
using System.Collections.Generic;

namespace domain.models
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
        public IEnumerable<ActivityTypeInstructor> activityTypeInstructors { get; set; }
    }
}
