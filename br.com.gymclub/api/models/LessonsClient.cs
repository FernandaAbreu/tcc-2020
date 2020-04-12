using System;

namespace api.models
{
    public class LessonsClient
    {
        public int Id { get; set; }
        public int idRegistration { get; set; }
        public int idLesson { get; set; }
   
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Client client { get; set; }
        public Lesson lesson { get; set; }

    }


    
 
}