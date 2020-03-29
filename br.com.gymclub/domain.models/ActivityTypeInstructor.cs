using System;

namespace domain.models
{
    public class ActivityTypeInstructor
    {
        public int Id { get; set; }
        public int idTypeActivity { get; set; }
        public int idInstructor { get; set; }
       public Instructor instructor { get; set; }
        public TypeActivity typeActivity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }


    }




}