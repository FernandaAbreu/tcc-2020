using System;

namespace domain.models
{
    public class ActivityTypeInstructor
    {
        public int Id { get; set; }
        public int idActividade { get; set; }
        public int idInstructor { get; set; }
       public Instructor instructor { get; set; }
        public TypeActivity TypeActivity { get; set; }

    }


    
 
}