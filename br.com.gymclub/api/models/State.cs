using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.models
{
    public class State
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public IEnumerable<User> users { get; set; }
        public IEnumerable<City> cities { get; set; }
        public IEnumerable<Client> clients { get; set; }
        public IEnumerable<Instructor> instructors { get; set; }
    }


    
 
}