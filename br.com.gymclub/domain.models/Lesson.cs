using System;

namespace domain.models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string InitialHour { get; set; }
        public string EndHour { get; set; }
        public int idTypeClass { get; set; }
        public int idDaysWeek { get; set; }
        public int idClassRoom { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        
    }


    
 
}