using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.models
{
    public class City
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public int state_id { get; set; }
        public int ibgeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public IEnumerable<User> Users { get; set; }
        public State state { get; set; }
        public IEnumerable<Client> clients { get; set; }
        public IEnumerable<Instructor> instructors { get; set; }
    }


    
 
}