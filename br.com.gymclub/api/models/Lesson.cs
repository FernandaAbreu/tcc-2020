using System;
using System.Collections.Generic;

namespace api.models
{
    public class Lesson
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String InitialHour { get; set; }
        public String EndHour { get; set; }
        public int idTypeClass { get; set; }
        public int idDaysWeek { get; set; }
        public int idClassRoom { get; set; }
        public int idInstructor { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ClassType classType { get; set; }
        public DaysWeek daysWeek { get; set; }
        public ClassRoom classRoom { get; set; }
        public Instructor instructor { get; set; }
        public IEnumerable<LessonsClient> lessonsClients { get; set; }

    }


    
 
}